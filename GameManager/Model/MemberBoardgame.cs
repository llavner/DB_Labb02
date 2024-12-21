using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Model
{
    public class MemberBoardgame
    {

        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int BoardgameId { get; set; }
        public Boardgame Boardgame { get; set; }

    }
}
