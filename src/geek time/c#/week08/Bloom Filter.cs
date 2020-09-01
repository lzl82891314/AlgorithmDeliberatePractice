using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace week08 {
    public class BloomFilter {
        private BitArray bitArray;
        private int size;
        private int hashNum;

        public BloomFilter(int size, int hashNum) {
            this.size = size;
            this.hashNum = hashNum;
            this.bitArray = new BitArray(this.size);
        }

        public void Add(string data) {
            for (var i = 1; i <= this.hashNum; i++) {
                var result = Hash(data, i) % this.size;
                this.bitArray[result] = true;
            }
        }

        public string LookUp(string data) {
            for (var i = 1; i <= this.hashNum; i++) {
                var result = Hash(data, i) % this.size;
                if (!this.bitArray[result]) return "Nope";
            }
            return "Probably";
        }

        private int Hash(string data, int seed) {
            // to be implement ...
            var code = 0;
            return code;
        }
    }
}