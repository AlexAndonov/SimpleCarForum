using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCarForum.Infra.Data.Constants
{
    public class ValidationConstants
    {
          // User First Name Max Length
        public const int ApplicationUserFirstNameMaxLength = 50;

        // User Last Name Max Length
        public const int ApplicationUserLastNameMaxLength = 50;

        // Maximal Post Title Length
        public const int PostTitleMaxLength = 50;

        ///Minimal Post Title Length
        public const int PostTitleMinLength = 10;

        // Maximal Content Length
        public const int PostContentMaxLength = 1500;

        // Minimal Content Length
        public const int PostContentMinLength = 30;
    }
}
