using System.Collections.Generic;

using Sandbox;

namespace TTTReborn.Items
{
    public abstract partial class Weapon
    {
        public virtual ItemInfo Info { get; private set; } = new WeaponInfo();

        public virtual WeaponInfo WeaponInfo
        {
            get => Info as WeaponInfo;
            set => Info = value;
        }

        public virtual ClipInfo Primary { get; set; } = new();

        public virtual ClipInfo Secondary { get; set; } = null;

        public bool IsReloading
        {
            get => PrimaryData.IsReloading || Secondary != null && SecondaryData.IsReloading;
        }

        public virtual float BulletRange { get; set; } = 20000f;

        [Net, Predicted]
        public TimeSince TimeSinceDeployed { get; set; }

        public PickupTrigger PickupTrigger { get; set; }

        private const int AMMO_DROP_POSITION_OFFSET = 50;
        private const int AMMO_DROP_VELOCITY = 500;

        [Net]
        public Entity LastDropOwner { get; set; }

        [Net, Predicted]
        public TimeSince TimeSinceLastDrop { get; set; }

        public abstract string ModelPath { get; }

        [Net, Predicted]
        public IList<ClipData> ClipDataList { get; set; }

        public ClipData PrimaryData
        {
            get => ClipDataList.Count > 0 ? ClipDataList[0] : null;
        }

        public ClipData SecondaryData
        {
            get => ClipDataList.Count > 1 ? ClipDataList[1] : null;
        }
    }
}
