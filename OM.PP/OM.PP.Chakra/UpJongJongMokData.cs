using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
	[Serializable]
    public class UpJongJongMokData
    {
		public string 종목명 { get; set; }
		public double 현재가 { get; set; }
		public string 전일대비구분 { get; set; }
		public double 전일대비 { get; set; }
		public double 등락율 { get; set; }
		public double 누적거래량 { get; set; }
		public double 시가 { get; set; }
		public double 고가 { get; set; }
		public double 저가 { get; set; }
		public double 소진율 { get; set; }
		public double 베타계수 { get; set; }
		public double PER { get; set; }
		public double 외인순매수 { get; set; }
		public double 기관순매수 { get; set; }
		public double 거래증가율 { get; set; }
		public string 종목코드 { get; set; }
		public double 시가총액 { get; set; }
		public double 거래대금 { get; set; }
	}
}
