using System;
using System.Reflection;
namespace MSPress.CSharpCoreRef.Authoring
{
    public class AuthorAttributeCheck
    {
        public AuthorAttributeCheck(Type theType)
        {
            _type = theType;
        }

        public string GetAuthorName()
        {
            foreach(Attribute attrib in _type.GetCustomAttributes(true))
            {
                AuthorAttribute auth = attrib as AuthorAttribute;
                if(auth != null)
                {
                    return auth.Name;
                }
            }
            return null;
        }

        public string GetNotes()
        {
            foreach(Attribute attrib in _type.GetCustomAttributes(true))
            {
                AuthorAttribute auth = attrib as AuthorAttribute;
                if(auth != null)
                {
                    return auth.Notes;
                }
            }
            return null;
        }

        public string[] GetMemberAuthorInfo(string memberName)
        {
            MemberInfo[] members = _type.GetMember(memberName);
            string [] result = new string[members.Length];
            int n = 0;
            foreach(MemberInfo info in members)
            {
                string name = info.Name;
                string memberType = info.MemberType.ToString();
                string author = MemberToAuthor(info);
                if(author == null)
                    author = "Not known";
                result[n] = memberType + ": " + name + ", author:" + author;
                ++n;
            }
            return result;
        }

        public string[] GetAllMemberAuthorInfo()
        {
            MemberInfo[] members = _type.GetMembers();
            string [] result = new string[members.Length];
            int n = 0;
            foreach(MemberInfo info in members)
            {
                string name = info.Name;
                string memberType = info.MemberType.ToString();
                string author = MemberToAuthor(info);
                if(author == null)
                    author = "Not known";
                result[n] = memberType + ": " + name + ", author:" + author;
                ++n;
            }
            return result;
        }

        protected string MemberToAuthor(MemberInfo info)
        {
            foreach(Attribute attrib in info.GetCustomAttributes(true))
            {
                AuthorAttribute auth = attrib as AuthorAttribute;
                if(auth != null)
                {
                    return auth.Name;
                }
            }
            return null;
        }

        public string GetAssemblyAuthorName(string asmName)
        {
            Assembly asm = Assembly.Load(asmName);
            if(asm != null)
            {
                foreach(Attribute attrib in asm.GetCustomAttributes(true))
                {
                    AuthorAttribute auth = attrib as AuthorAttribute;
                    if(auth != null)
                    {
                        return auth.Name;
                    }
                }
            }
            return null;
        }

        public string GetAssemblyAuthorNotes(string asmName)
        {
            Assembly asm = Assembly.Load(asmName);
            if(asm != null)
            {
                foreach(Attribute attrib in asm.GetCustomAttributes(true))
                {
                    AuthorAttribute auth = attrib as AuthorAttribute;
                    if(auth != null)
                    {
                        return auth.Notes;
                    }
                }
            }
            return null;
        }
        protected Type _type;
    }
}
