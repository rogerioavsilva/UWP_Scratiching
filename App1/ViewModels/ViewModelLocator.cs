using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator() { }

        private static TrucksVM _TrucksVM;
        public static TrucksVM TrucksVM
        {
            get 
            {
                if (_TrucksVM == null)
                    _TrucksVM = new TrucksVM();
                return _TrucksVM; 
            }
        }

    }
}
