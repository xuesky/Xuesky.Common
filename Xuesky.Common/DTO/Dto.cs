using System;
using System.Linq;
using Omu.ValueInjecter;
using Xuesky.Common.Models;

namespace Xuesky.Common.DTO
{
    public class Dto
    {
        public const string MsgDemo1 = "<xml><ToUserName><![CDATA[gh_a413ed7b46b6]]></ToUserName>" +
                               "<FromUserName><![CDATA[oinzFjmCt9LdPgmnEnvBShE0W5Qk]]></FromUserName>" +
                               "<CreateTime>1406179796</CreateTime>" +
                               "<MsgType><![CDATA[text]]></MsgType>" +
                               "<Content><![CDATA[this is client msg]]></Content>" +
                               "<MsgId>6039496236316578696</MsgId>" +
                               "</xml>";
        public void DtoTest()
        {
            Console.WriteLine("******************************使用ValueInjecter实现值注入*******************************************");
            Omu.ValueInjecter.Mapper.AddMap<Student, StudentDto>(src =>
            {
                var dto = new StudentDto
                {
                    id = src.id,
                    name = $"{src.fname}{src.lname}"
                };
                return dto;
            });
            var users1 = Omu.ValueInjecter.Mapper.Map<Student, StudentDto>(new Students().stus.First());
            Omu.ValueInjecter.Mapper.AddMap<Student, StudentDto>((src, tag) =>
            {
                var par = (Nametest)tag;
                var res = new StudentDto { name = par.Name };
                return res;
            });
            var users2 = Omu.ValueInjecter.Mapper.Map<StudentDto>(new Students().stus.First(), new Nametest { Name = "help" });

            var mapper1 = new MapperInstance();
            mapper1.AddMap<Student, Student>(o => new Student { fname = "mapper1" });

            var users3 = mapper1.Map<Student>(new Students().stus.First());
            TextMessage msg = new TextMessage();
            var s=msg.InjectFrom<XmlStrInjection>(MsgDemo1);
        }
    }

}
