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



        // Comment Content Max Length
        public const int CommentContentMaxLength = 500;

        // Comment Content Min Length
        public const int CommentContentMinLength = 3;



        //Category Name Max Length
        public const int CategoryNameMaxLength = 50;

        //Category Name Min Length
        public const int CategoryNameMinLength = 3;

        //Category Name Max Length
        public const int CategoryDescriptionMaxLength = 250;

        //Category Name Min Length
        public const int CategoryDescriptionMinLength = 10;



        // Required Field Error Message
        public const string RequiredFieldMessage = "The field {0} is required!";

        // Required Text Length Error Message
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} symbols!";
    }
}
