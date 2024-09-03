using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        //çift parametreli de bu constructor çalışır mesajda döner 
        public ErrorResult(string message) : base(false, message)
        {
        }
        //tek parametreli de ise burası çalışır ve sadece true dödürür 
        public ErrorResult() : base(false)
        {

        }
    }
}
