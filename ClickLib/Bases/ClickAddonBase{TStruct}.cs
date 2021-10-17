using System;

using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib
{
    /// <summary>
    /// AtkUnitBase receive event delegate.
    /// </summary>
    /// <param name="eventListener">Type receiving the event.</param>
    /// <param name="evt">Event type.</param>
    /// <param name="which">Internal routing number.</param>
    /// <param name="eventData">Event data.</param>
    /// <param name="inputData">Keyboard and mouse data.</param>
    /// <returns>The addon address.</returns>
    internal unsafe delegate IntPtr ReceiveEventDelegate(void* eventListener, EventType evt, uint which, IntPtr eventData, IntPtr inputData);

    /// <summary>
    /// Click base class.
    /// </summary>
    /// <typeparam name="TStruct">FFXIVClientStructs addon type.</typeparam>
    public abstract unsafe class ClickAddonBase<TStruct> : ClickBase where TStruct : unmanaged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickAddonBase{TStruct}"/> class.
        /// </summary>
        /// <param name="addon">Addon address.</param>
        public ClickAddonBase(IntPtr addon)
        {
            if (addon == default)
                addon = this.GetAddonByName(this.AddonName);

            this.AddonAddress = addon;
            this.Addon = (TStruct*)addon;
        }

        /// <summary>
        /// Gets the associated addon name.
        /// </summary>
        protected abstract string AddonName { get; }

        /// <summary>
        /// Gets a pointer to the addon.
        /// </summary>
        protected IntPtr AddonAddress { get; }

        /// <summary>
        /// Gets a pointer to the type.
        /// </summary>
        protected TStruct* Addon { get; }

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonButton(AtkUnitBase* addonBase, AtkComponentButton* target, uint which, EventType type = EventType.CHANGE)
            => ClickAddonComponent(addonBase, target->AtkComponentBase.OwnerNode, which, type);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonRadioButton(AtkUnitBase* addonBase, AtkComponentRadioButton* target, uint which, EventType type = EventType.CHANGE)
            => ClickAddonComponent(addonBase, target->AtkComponentBase.OwnerNode, which, type);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonCheckBox(AtkUnitBase* addonBase, AtkComponentCheckBox* target, uint which, EventType type = EventType.CHANGE)
            => ClickAddonComponent(addonBase, target->AtkComponentButton.AtkComponentBase.OwnerNode, which, type);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonDragDrop(AtkUnitBase* addonBase, AtkComponentDragDrop* target, uint which, EventType type = EventType.ICON_TEXT_ROLL_OUT)
            => ClickAddonComponent(addonBase, target->AtkComponentBase.OwnerNode, which, type);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonStage(AtkUnitBase* addonBase, AtkStage* target, uint which, EventType type = EventType.MOUSE_CLICK)
        {
            var eventData = EventData.ForNormalTarget(target, addonBase);
            var inputData = InputData.Empty();

            InvokeReceiveEvent(&addonBase->AtkEventListener, type, which, eventData, inputData);

            eventData.Dispose();
            inputData.Dispose();
        }

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        /// <param name="eventData">Event data.</param>
        /// <param name="inputData">Input data.</param>
        protected static void ClickAddonComponent(AtkUnitBase* addonBase, AtkComponentNode* target, uint which, EventType type, EventData? eventData = null, InputData? inputData = null)
        {
            eventData ??= EventData.ForNormalTarget(target, addonBase);
            inputData ??= InputData.Empty();

            InvokeReceiveEvent(&addonBase->AtkEventListener, type, which, eventData, inputData);

            eventData.Dispose();
            inputData.Dispose();
        }

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="popupMenu">PopupMenu event listener.</param>
        /// <param name="index">List index.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonList(PopupMenu* popupMenu, ushort index, EventType type = EventType.LIST_INDEX_CHANGE)
        {
            var targetList = popupMenu->List;
            if (index < 0 || index >= popupMenu->EntryCount)
                throw new ArgumentOutOfRangeException(nameof(index), "List index is out of range");

            var eventData = EventData.ForNormalTarget(targetList->AtkComponentBase.OwnerNode, popupMenu);
            var inputData = InputData.ForPopupMenu(popupMenu, index);

            InvokeReceiveEvent(&popupMenu->AtkEventListener, type, 0, eventData, inputData);

            eventData.Dispose();
            inputData.Dispose();
        }

        private IntPtr GetAddonByName(string name, int index = 1)
        {
            var atkStage = AtkStage.GetSingleton();
            if (atkStage == null)
                throw new InvalidClickException("AtkStage is not available");

            var unitMgr = atkStage->RaptureAtkUnitManager;
            if (unitMgr == null)
                throw new InvalidClickException("UnitMgr is not available");

            var addon = unitMgr->GetAddonByName(name, index);
            if (addon == null)
                throw new InvalidClickException("Addon is not available");

            return (IntPtr)addon;
        }
    }
}
