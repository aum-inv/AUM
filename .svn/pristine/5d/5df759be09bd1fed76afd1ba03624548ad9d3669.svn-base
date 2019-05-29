using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OM.PP.XingApp.Config
{
    public class WorldFutureAccountInfo
    {
        public static string LoginUser { get; set; } = "";
        public static string 계좌번호
        {
            get
            {
                if (LoginUser == "LEE")
                    return WorldFutureAccountInfoLEE.계좌번호;
                if (LoginUser == "SON")
                    return WorldFutureAccountInfoSON.계좌번호;
                if (LoginUser == "JIN")
                    return WorldFutureAccountInfoJIN.계좌번호;
                if (LoginUser == "JUNG")
                    return WorldFutureAccountInfoJUNG.계좌번호;

                return WorldFutureAccountInfoLEE.계좌번호;
            }
        }
        public static string 계좌비밀번호
        {
            get
            {
                if (LoginUser == "LEE")
                    return WorldFutureAccountInfoLEE.계좌비밀번호;
                if (LoginUser == "SON")
                    return WorldFutureAccountInfoSON.계좌비밀번호;
                if (LoginUser == "JIN")
                    return WorldFutureAccountInfoJIN.계좌비밀번호;
                if (LoginUser == "JUNG")
                    return WorldFutureAccountInfoJUNG.계좌비밀번호;

                return WorldFutureAccountInfoLEE.계좌비밀번호;
            }
        }
    }
    public class WorldFutureAccountInfoLEE
    {
        public static bool IsUseSystemOrder = false;
        public static string 계좌번호 = "20069901104";
        public static string 계좌비밀번호 = "7607";     
    }
    public class WorldFutureAccountInfoJIN
    {
        public static bool IsUseSystemOrder = false;
        public static string 계좌번호 = "555-55-013499";
        public static string 계좌비밀번호 = "0000";
    }
    public class WorldFutureAccountInfoSON
    {
        public static bool IsUseSystemOrder = false;
        public static string 계좌번호 = "20216943603";
        public static string 계좌비밀번호 = "2325";
    }
    public class WorldFutureAccountInfoJUNG
    {
        public static bool IsUseSystemOrder = false;
        public static string 계좌번호 = "555-55-013499";
        public static string 계좌비밀번호 = "0000";
    }
}
