using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmail
{
    // 1. 自定义Collection类 - http://blog.csdn.net/haifengzhilian/article/details/8834513
    // 2. C#中Collection，List和ArrayList的区别 - http://blog.csdn.net/cronzb/article/details/6429241
    // 3. C# 常用接口学习 ICollection<T> - https://www.cnblogs.com/leemano/p/4928899.html
    public abstract class MailMessageCollectionBase : CollectionBase, ICollection<EmailMessageBase>
    {
        public bool IsReadOnly => false;

        public void Add(EmailMessageBase item)
        {
            InnerList.Add(item);
        }

        public bool Contains(EmailMessageBase item)
        {
            return InnerList.Contains(item);
        }

        public void CopyTo(EmailMessageBase[] messages, int index)
        {
            InnerList.CopyTo(messages, index);
        }

        public bool Remove(EmailMessageBase item)
        {
            InnerList.Remove(item);

            return true;
        }

        /// <summary>
        /// Build Email Message List
        /// </summary>
        /// <returns>Email Message List</returns>
        public abstract List<MailMessage> Build();

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in InnerList) yield return item;
        }

        IEnumerator<EmailMessageBase> IEnumerable<EmailMessageBase>.GetEnumerator()
        {
            foreach (var item in InnerList) yield return item as EmailMessageBase;
        }
    }
}
