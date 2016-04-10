using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace MIDI
{
    public class KnownHardwareList : List<Type> {

        void findAllHardwareEnums() {
            var query = (from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.IsEnum
                let attrs = type.GetCustomAttributes(true)
                where attrs.Any(a => a.GetType() == typeof(HardwareControlMapping))
                select type
            );

            foreach (Type t in query) {
                this.Add(t);
            }
        }

        public KnownHardwareList () {
            findAllHardwareEnums();
        }
    }
}

