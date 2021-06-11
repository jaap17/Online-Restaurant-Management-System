using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdp.ViewModels
{
    public class MenuEditViewModel:MenuCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
