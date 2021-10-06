using System;
using System.Runtime.InteropServices;

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib
{
    /// <summary>
    /// AtkUnitBase receive event delegate.
    /// </summary>
    /// <param name="addon">Addon receiving the event.</param>
    /// <param name="evt">Event type.</param>
    /// <param name="which">Internal routing number.</param>
    /// <param name="eventData">Event data.</param>
    /// <param name="inputData">Keyboard and mouse data.</param>
    /// <returns>The addon address.</returns>
    internal delegate IntPtr ReceiveEventDelegate(IntPtr addon, EventType evt, uint which, IntPtr eventData, IntPtr inputData);

    /// <summary>
    /// Click base class.
    /// </summary>
    /// <typeparam name="T">FFXIVClientStructs addon type.</typeparam>
    public abstract unsafe class ClickBase<T> : ClickBase where T : unmanaged
    {
        private ReceiveEventDelegate? receiveEvent = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClickBase{T}"/> class.
        /// </summary>
        /// <param name="addon">Addon address.</param>
        public ClickBase(IntPtr addon)
        {
            if (addon == default)
                addon = this.GetAddonByName(this.AddonName);

            this.Address = addon;
            this.Type = (T*)addon;
        }

        /// <summary>
        /// Gets the associated addon name.
        /// </summary>
        protected abstract string AddonName { get; }

        /// <summary>
        /// Gets a pointer to the addon.
        /// </summary>
        protected IntPtr Address { get; }

        /// <summary>
        /// Gets a pointer to the type.
        /// </summary>
        protected T* Type { get; }

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickButton(uint which, AtkComponentButton* target, EventType type = EventType.CHANGE)
            => this.ClickComponent(type, which, target->AtkComponentBase.OwnerNode);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickRadioButton(uint which, AtkComponentRadioButton* target, EventType type = EventType.CHANGE)
            => this.ClickComponent(type, which, target->AtkComponentBase.OwnerNode);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickCheckBox(uint which, AtkComponentCheckBox* target, EventType type = EventType.CHANGE)
            => this.ClickComponent(type, which, target->AtkComponentButton.AtkComponentBase.OwnerNode);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickDragDrop(uint which, AtkComponentDragDrop* target, EventType type = EventType.ICON_TEXT_ROLL_OUT)
            => this.ClickComponent(type, which, target->AtkComponentBase.OwnerNode);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickStage(uint which, AtkStage* target, EventType type = EventType.MOUSE_CLICK)
        {
            var eventData = Marshal.AllocHGlobal(0x18);
            var inputData = Marshal.AllocHGlobal(0x40);

            Marshal.WriteIntPtr(eventData, 0x8, (IntPtr)target);
            Marshal.WriteIntPtr(eventData, 0x10, this.Address);

            this.SendClick(type, which, eventData, inputData);

            Marshal.FreeHGlobal(eventData);
            Marshal.FreeHGlobal(inputData);
        }

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="index">List index.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickList(ushort index, AtkComponentList* target, EventType type = EventType.LIST_INDEX_CHANGE)
        {
            if (index < 0 || index >= target->ListLength)
                throw new ArgumentOutOfRangeException(nameof(index), "List index is out of range");

            var eventData = Marshal.AllocHGlobal(0x18);
            var inputData = Marshal.AllocHGlobal(0x40);

            Marshal.WriteIntPtr(eventData, 0x8, (IntPtr)target->AtkComponentBase.OwnerNode);
            Marshal.WriteIntPtr(eventData, 0x10, this.Address);

            Marshal.WriteIntPtr(inputData, (IntPtr)target->ItemRendererList[index].AtkComponentListItemRenderer);
            Marshal.WriteInt16(inputData, 0x10, (short)index);
            Marshal.WriteInt16(inputData, 0x16, (short)index);

            this.SendClick(type, index, eventData, inputData);

            Marshal.FreeHGlobal(eventData);
            Marshal.FreeHGlobal(inputData);
        }

        private void ClickComponent(EventType type, uint which, AtkComponentNode* target)
        {
            var eventData = Marshal.AllocHGlobal(0x18);
            var inputData = Marshal.AllocHGlobal(0x40);

            Marshal.WriteIntPtr(eventData, 0x8, (IntPtr)target);
            Marshal.WriteIntPtr(eventData, 0x10, this.Address);

            this.SendClick(type, which, eventData, inputData);

            Marshal.FreeHGlobal(eventData);
            Marshal.FreeHGlobal(inputData);
        }

        private void SendClick(EventType type, uint which, IntPtr eventData, IntPtr clickData)
        {
            if (this.receiveEvent == null)
            {
                var eventListener = (AtkEventListener*)this.Type;
                var receiveEventAddress = new IntPtr(eventListener->vfunc[2]);
                this.receiveEvent = Marshal.GetDelegateForFunctionPointer<ReceiveEventDelegate>(receiveEventAddress)!;
            }

            this.receiveEvent(this.Address, type, which, eventData, clickData);
        }

        private IntPtr GetAddonByName(string name, int index = 1)
        {
            var atkStage = AtkStage.GetSingleton();
            var unitMgr = atkStage->RaptureAtkUnitManager;
            var addon = unitMgr->GetAddonByName(name, index);

            if (addon == null)
                throw new InvalidClickException("Window is not available for that click");

            return (IntPtr)addon;
        }
    }
}
