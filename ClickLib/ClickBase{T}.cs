using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib
{
    /// <summary>
    /// AtkUnitBase receive event delegate.
    /// </summary>
    /// <param name="addon">Addon receiving the event.</param>
    /// <param name="evt">Event type.</param>
    /// <param name="which">Internal routing number.</param>
    /// <param name="target">Target node.</param>
    /// <param name="unused">Keyboard and mouse data.</param>
    internal unsafe delegate void ReceiveEventDelegate(IntPtr addon, EventType evt, uint which, void* target, void* unused);

    /// <summary>
    /// Click base class.
    /// </summary>
    /// <typeparam name="T">FFXIVClientStructs addon type.</typeparam>
    public abstract unsafe class ClickBase<T> : ClickBase where T : unmanaged
    {
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
        protected IntPtr Address { get; init; }

        /// <summary>
        /// Gets a pointer to the type.
        /// </summary>
        protected T* Type { get; init; }

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickButton(uint which, AtkComponentButton* target, EventType type = EventType.CHANGE)
            => this.SendClick(type, which, target->AtkComponentBase.OwnerNode);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickRadioButton(uint which, AtkComponentRadioButton* target, EventType type = EventType.CHANGE)
            => this.SendClick(type, which, target->AtkComponentBase.OwnerNode);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickDragDrop(uint which, AtkComponentDragDrop* target, EventType type = EventType.ICON_TEXT_ROLL_OUT)
            => this.SendClick(type, which, target->AtkComponentBase.OwnerNode);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickCheckBox(uint which, AtkComponentCheckBox* target, EventType type = EventType.ICON_TEXT_ROLL_OUT)
            => this.SendClick(type, which, target->AtkComponentButton.AtkComponentBase.OwnerNode);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="target">Target node.</param>
        /// <param name="type">Event type.</param>
        protected void ClickStage(uint which, AtkStage* target, EventType type = EventType.MOUSE_CLICK)
            => this.SendClick(type, which, target);

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

            using var eventData = EventData.Create(target->ItemRendererList[index].AtkComponentListItemRenderer, index);
            using var clickData = new InputData(this.Address, target);

            this.SendClick(type, index, eventData, clickData);
        }

        private void SendClick(EventType type, uint which, void* target)
        {
            using var eventData = EventData.CreateEmpty();
            using var clickData = new InputData(this.Address, target);

            this.SendClick(type, which, eventData, clickData);
        }

        private void SendClick(EventType type, uint which, EventData eventData, InputData clickData)
        {
            // var receiveEvent = this.GetReceiveEventDelegate(this.Address);
            // receiveEvent(this.Address, type, which, eventData.Data, clickData.Data);
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

        private ReceiveEventDelegate GetReceiveEventDelegate(IntPtr addon)
        {
            var eventListener = (AtkEventListener*)addon;
            var receiveEventAddress = new IntPtr(eventListener->vfunc[2]);
            return Marshal.GetDelegateForFunctionPointer<ReceiveEventDelegate>(receiveEventAddress)!;
        }

        private readonly struct EventData : IDisposable
        {
            public readonly byte** Data;

            private const int AllocSize = 0x18;

            private EventData(void* target, void* unk)
            {
                this.Data = (byte**)Marshal.AllocHGlobal(AllocSize).ToPointer();
                this.Data[0] = (byte*)unk;
                this.Data[1] = (byte*)target;
                this.Data[2] = (byte*)0x0805;
            }

            private EventData(AtkComponentListItemRenderer* target, ushort index)
            {
                this.Data = (byte**)Marshal.AllocHGlobal(AllocSize).ToPointer();
                this.Data[0] = (byte*)target;
                this.Data[1] = null;
                this.Data[2] = (byte*)(index | ((ulong)index << 48));
            }

            public static EventData Create(AtkComponentListItemRenderer* target, ushort index)
                => new(target, index);

            public static EventData Create(AtkComponentButton* target)
                => new(target, (byte*)0);

            public static EventData Create(AtkComponentRadioButton* target)
                => new(target, (byte*)0);

            public static EventData Create(AtkComponentDragDrop* target)
                => new(target, (byte*)0);

            public static EventData Create(AtkComponentCheckBox* target)
                => new(target, (byte*)0);

            public static EventData Create(AtkStage* target)
                => new(target, (byte*)0);

            public static EventData CreateEmpty()
                => new(null, (byte*)0);

            public void Dispose()
            {
                var ptr = new IntPtr(this.Data);

                Task.Delay(10000)
                    .ContinueWith(task => Marshal.FreeHGlobal(ptr));
            }

            public override string? ToString()
                => $"{nameof(EventData)}: {(ulong)this.Data[0]:X}, {(ulong)this.Data[1]:X}, {(ulong)this.Data[2]:X}";
        }

        private readonly struct InputData : IDisposable
        {
            public readonly byte** Data;

            private const int AllocSize = 0x40;

            public InputData(IntPtr window, void* target)
            {
                this.Data = (byte**)Marshal.AllocHGlobal(AllocSize).ToPointer();
                this.Data[0] = null;
                this.Data[1] = (byte*)target;
                this.Data[2] = (byte*)window;
                this.Data[3] = null;
                this.Data[4] = null;
                this.Data[5] = null;
                this.Data[6] = null;
                this.Data[7] = null;
                this.Data[8] = null;
            }

            public void Dispose()
            {
                var ptr = new IntPtr(this.Data);

                Task.Delay(10000)
                    .ContinueWith(task => Marshal.FreeHGlobal(ptr));
            }

            public override string? ToString()
                => $"{nameof(InputData)}: {(long)this.Data[1]:X}, {(long)this.Data[2]:X}";
        }
    }
}
