using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xuesky.Common.Models;

namespace Xuesky.Common.ListDemo
{
    public class PersonList : IEnumerable<Person>
    {
        public IEnumerator<Person> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
