using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LaunchPad.Settings
{
    [Serializable]
    public abstract class TextSettingsReader
    {
        protected Dictionary<string, string> ParseFile( string filename )
        {
            var settingsDictionary = new Dictionary<string, string>();

            try
            {
                var file = File.ReadAllLines( filename );
                foreach ( var line in file )
                {
                    var splitLine = line.Split( new char[] { '=' }, 2 );
                    if ( splitLine.Length < 2 )
                    {
                        continue;
                    }
                    settingsDictionary[splitLine[0]] = splitLine[1];
                }
            }
            catch ( FileNotFoundException )
            { }

            return settingsDictionary;
        }


        protected void WriteFile( string filename, Dictionary<string, string> settings )
        {
            var lines = new List<string>();
            foreach ( var line in settings )
            {
                lines.Add( line.Key.Trim() + "=" + line.Value.Trim() );
            }
            File.WriteAllLines( filename, lines.ToArray() );
        }
    }
}
