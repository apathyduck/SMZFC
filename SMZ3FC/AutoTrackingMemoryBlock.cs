using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    class AutoTrackingMemoryBlock
    {
        

        public AutoTrackingMemoryBlock PreviousBlock { get; set; }

        public AutoTrackingMemoryBlock NextBlock { get; set; }

        public uint InitialAddressOffset { get; set; } = 0;

        public uint FinalAddressOffset 
        {
            get
            {
                return InitialAddressOffset + BlockSize - 1;
            }
        }

        public uint MaxAllowedAddress
        {

            get
            {
                return InitialAddressOffset + MaxBlockSize - 1;
            }
        }

        public uint BlockSize { get; set; } = 0;

        public uint MaxBlockSize { get; } = 0x280;

        private ulong[] mMemoryChunks;

        private bool mInit = false;

        public List<ActiveLocation> BlockLocations { get; set; } = new List<ActiveLocation>();

        public AutoTrackingMemoryBlock(AutoTrackingMemoryBlock mb)
        {
            PreviousBlock = mb;
        }


        public AutoTrackingMemoryBlock AddMemoryLocation(ActiveLocation al)
        {

            uint address = (uint)al.Info.AddressOffset;
            //Nothing added yet, just initialize
            if(!mInit)
            {
                InitialAddressOffset = address;
                BlockSize = 1;
                BlockLocations.Add(al);
                mInit = true;
                return this;
            }

            //If were within the block size weve already been added
            if (FinalAddressOffset >= address)
            {
                BlockLocations.Add(al);
                return this;
            }

            //Were full need to add a new block
            if(address > MaxAllowedAddress)
            {
                AutoTrackingMemoryBlock mb = new AutoTrackingMemoryBlock(this);
                mb.AddMemoryLocation(al);
                NextBlock = mb;
                CreateChunks();
                return mb;
            }

            BlockSize = address - InitialAddressOffset + 1;
            BlockLocations.Add(al);
            return this;
        }

        //Todo: Add smart memory watches
        public void SetMemoryValue(byte[] data)
        {        
            for (int n = 0; n < data.Count(); n++)
            {
                int c = n / 8;
                int m = n % 8;

                ulong mask = 255UL << (m * 8);
                mMemoryChunks[c] &= ~mask;
                ulong value = data[n];
                mMemoryChunks[c] = mMemoryChunks[c] + (value << (m * 8));    
            }

            foreach(ActiveLocation al in BlockLocations)
            {
                uint add = (uint)al.Info.AddressOffset;

                uint offset = add - InitialAddressOffset;
                uint chunknum = offset / 8;
                int addloc = (int)((offset - (chunknum * 8))*8);
                byte value = (byte)((mMemoryChunks[chunknum] >> addloc) & 255UL);

                al.AddressValue = value;

            }

        }

        public void CreateChunks()
        {

            uint chunks = (BlockSize + 7) / 8;
            mMemoryChunks = new ulong[chunks];
            
        }



    }
}
