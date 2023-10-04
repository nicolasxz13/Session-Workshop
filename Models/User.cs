using System.ComponentModel.DataAnnotations;

namespace Session_Workshop.Models{
    public class User{
        [Required(ErrorMessage ="Name is required!")]
        public string Name{get;set;}

    }
}