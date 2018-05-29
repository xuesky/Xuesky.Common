using System.Xml.Linq;
using Omu.ValueInjecter.Injections;

namespace Xuesky.Common.DTO
{
    public class XmlStrInjection: KnownSourceInjection<string>
    {
        private string _student = "name";

        public XmlStrInjection(string student) => this._student = student;

        public XmlStrInjection()
        {
        }

        protected override void Inject(string source, object target)
        {
            var xElement = XElement.Parse(source);
            var nodes = xElement.Nodes();
            foreach (var xNode1 in nodes)
            {
                var xNode = (XElement) xNode1;
                var name = xNode.Name.LocalName;
                var value = xNode.Value;
                var targetPro = target.GetType().GetProperty(name);
                if (targetPro == null) continue;
                targetPro.SetValue(target, value);
            }
        }
    }
}
