using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Authentication
{
    class Response
    {
        public Challenge @Challenge { get; private set; }
        public string @ResponseString { get; set; }

        public Response( Challenge challenge )
        {
            @Challenge = challenge;
        }

        public bool Validate()
        {
            // TODO
            return true;

            // If the challenge was created within 5 minutes
            // and Decrypt( ResponseString ) == Timestamp
            // then return true; otherwise return false;

            var expiration = DateTime.Now.AddMinutes( -5 );
            if ( Challenge.Timestamp.CompareTo( expiration ) >= 0 )
            {
                // TODO: return Decrypt( ResponseString ) == Timestamp
            }
            return false;
        }

        public override string ToString()
        {
            return ResponseString;
        }
    }
}
