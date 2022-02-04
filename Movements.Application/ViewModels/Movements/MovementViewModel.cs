using System;
using Template.Application.ViewModels.Profiles;

namespace Template.Application.ViewModels.Users
{
    public class MovementViewModel
	{
        public int Month { get; set; }

        public int Year { get; set; }

        public string CodProduct { get; set; }

        public int EntryNumber { get; set; }

        public string Description { get; set; }

        public DateTime MovimentDate { get; set; }

        public string UserCode { get; set; }

        public int Value { get; set; }
    }
}
