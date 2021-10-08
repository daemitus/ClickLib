using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib
{
    /// <summary>
    /// Searchable click base class.
    /// </summary>
    public abstract unsafe class ClickBase
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
        internal unsafe delegate IntPtr ReceiveEventDelegate(void* eventListener, EventType evt, uint which, void* eventData, void* inputData);

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonButton(AtkUnitBase* addonBase, AtkComponentButton* target, uint which, EventType type = EventType.CHANGE)
        {
            ClickAddonComponent(addonBase, target->AtkComponentBase.OwnerNode, which, type);
        }

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonRadioButton(AtkUnitBase* addonBase, AtkComponentRadioButton* target, uint which, EventType type = EventType.CHANGE)
        {
            ClickAddonComponent(addonBase, target->AtkComponentBase.OwnerNode, which, type);
        }

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonCheckBox(AtkUnitBase* addonBase, AtkComponentCheckBox* target, uint which, EventType type = EventType.CHANGE)
        {
            ClickAddonComponent(addonBase, target->AtkComponentButton.AtkComponentBase.OwnerNode, which, type);
        }

        // TODO
        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonDragDrop(AtkUnitBase* addonBase, AtkComponentDragDrop* target, uint which, EventType type = EventType.ICON_TEXT_ROLL_OUT)
        {
            ClickAddonComponent(addonBase, target->AtkComponentBase.OwnerNode, which, type);
        }

        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        /// <param name="eventPtr">Event data.</param>
        /// <param name="inputPtr">Input data.</param>
        protected static void ClickAddonComponent(AtkUnitBase* addonBase, AtkComponentNode* target, uint which, EventType type, EventData? eventData = null, InputData? inputData = null)
        {
            eventData ??= new EventData(target, addonBase);
            inputData ??= new InputData();

            InvokeReceiveEvent(&addonBase->AtkEventListener, which, type, eventData, inputData);

            eventData.Dispose();
            inputData.Dispose();
        }

        // TODO
        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="addonBase">The click recipient.</param>
        /// <param name="target">Target node.</param>
        /// <param name="which">Internal game click routing.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonStage(AtkUnitBase* addonBase, AtkStage* target, uint which, EventType type = EventType.MOUSE_CLICK)
        {
            var eventData = new EventData(target, addonBase);
            var inputData = new InputData();

            InvokeReceiveEvent(&addonBase->AtkEventListener, which, type, eventData, inputData);

            eventData.Dispose();
            inputData.Dispose();
        }

        // TODO
        /// <summary>
        /// Send a click.
        /// </summary>
        /// <param name="index">List index.</param>
        /// <param name="popupMenu">PopupMenu event listener.</param>
        /// <param name="type">Event type.</param>
        protected static void ClickAddonList(ushort index, PopupMenu* popupMenu, EventType type = EventType.LIST_INDEX_CHANGE)
        {
            var targetList = popupMenu->List;
            if (index < 0 || index >= popupMenu->EntryCount)
                throw new ArgumentOutOfRangeException(nameof(index), "List index is out of range");

            var eventData = new EventData(targetList->AtkComponentBase.OwnerNode, popupMenu);
            var inputData = new InputData(popupMenu, index);

            InvokeReceiveEvent(&popupMenu->AtkEventListener, 0, type, eventData, inputData);

            eventData.Dispose();
            inputData.Dispose();
        }

        private static void InvokeReceiveEvent(AtkEventListener* eventListener, uint which, EventType type, EventData eventData, InputData clickData)
        {
            var receiveEvent = GetReceiveEvent(eventListener);
            receiveEvent(eventListener, type, which, eventData.Data, clickData.Data);
        }

        private static ReceiveEventDelegate GetReceiveEvent(AtkEventListener* listener)
        {
            var receiveEventAddress = new IntPtr(listener->vfunc[2]);
            return Marshal.GetDelegateForFunctionPointer<ReceiveEventDelegate>(receiveEventAddress)!;
        }

        /// <summary>
        /// Event data.
        /// </summary>
        public sealed class EventData : IDisposable
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="EventData"/> class.
            /// </summary>
            /// <param name="target">Target.</param>
            /// <param name="listener">Event listener.</param>
            public EventData(void* target, void* listener)
            {
                this.Data = (void**)Marshal.AllocHGlobal(0x18).ToPointer();
                this.Data[0] = null;
                this.Data[1] = target;
                this.Data[2] = listener;
            }

            /// <summary>
            /// Gets the data pointer.
            /// </summary>
            public void** Data { get; }

            /// <inheritdoc/>
            public void Dispose()
            {
                Task.Run(() =>
                {
                    Task.Delay(10000).Wait();
                    Marshal.FreeHGlobal((IntPtr)this.Data);
                });
            }
        }

        /// <summary>
        /// Input data.
        /// </summary>
        public sealed class InputData : IDisposable
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InputData"/> class.
            /// </summary>
            public InputData()
            {
                this.Data = (void**)Marshal.AllocHGlobal(0x40).ToPointer();
                this.Data[0] = (void*)0;
                this.Data[1] = null;
                this.Data[2] = null;
                this.Data[3] = null;
                this.Data[4] = null;
                this.Data[5] = null;
                this.Data[6] = (void*)1;
                this.Data[7] = null;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="InputData"/> class.
            /// </summary>
            /// <param name="popupMenu">List popup menu.</param>
            /// <param name="index">Selected index.</param>
            public InputData(PopupMenu* popupMenu, ushort index)
            {
                this.Data = (void**)Marshal.AllocHGlobal(0x40).ToPointer();
                this.Data[0] = popupMenu->List->ItemRendererList[index].AtkComponentListItemRenderer;
                this.Data[1] = null;
                this.Data[2] = (void*)(index | ((ulong)index << 48));
                this.Data[3] = null;
                this.Data[4] = null;
                this.Data[5] = null;
                this.Data[6] = null;
                this.Data[7] = null;
            }

            /// <summary>
            /// Gets the data pointer.
            /// </summary>
            public void** Data { get; }

            /// <inheritdoc/>
            public void Dispose()
            {
                Task.Run(() =>
                {
                    Task.Delay(10000).Wait();
                    Marshal.FreeHGlobal((IntPtr)this.Data);
                });
            }
        }
    }
}
