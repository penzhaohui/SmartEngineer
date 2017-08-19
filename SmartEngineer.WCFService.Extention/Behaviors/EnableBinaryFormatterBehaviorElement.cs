using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.WCFService.Ext.Behaviors
{
    /// <summary> 
    /// 启用旧的 BinaryFormatter 来对数据进行序列化。 
    /// </summary> 
    public class EnableBinaryFormatterBehaviorElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(BinaryFormatterEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new BinaryFormatterEndpointBehavior();
        }
    }
}
