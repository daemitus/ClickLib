using System;
using System.Runtime.InteropServices;

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

            this.AddonAddress = addon;
            this.Addon = (T*)addon;
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
        protected T* Addon { get; }

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
