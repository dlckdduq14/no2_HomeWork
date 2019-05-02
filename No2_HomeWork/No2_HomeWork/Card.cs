using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No2_HomeWork
{
    //( private < protected < internal _헌프로젝트안에서만 접근가능 < public )
    public class Card //( public으로 했을땐 다른프로젝트에서도 사용가능) 
    {
        public Card(int no, bool isKwang)
        {
            _no = no;
            IsKwang = isKwang;
        }

        private int _no;  //자바의 기본 접근 지정자와 다름

        public int No
        {
            get
            {
                return _no;
            }
        }

        // 3.0 자동속성 auto property (자동으로 기반이되는 필드를 생성해 줌)
        public bool IsKwang { get; }
        public override string ToString()
        {
            if (IsKwang)
                return _no + "K";
            else
                return _no.ToString();

        }
    }
}
