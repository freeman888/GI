using GI;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace GTXAM
{
    
        /// <summary>
        /// 控件的虚拟父类
        /// </summary>
        class Control : IOBJ
        {
            View obj;
            public Control(View obj)
            {
                this.obj = obj;
            }
            public object IGetCSValue()
            {
                return obj;
            }

            public Variable IGetMember(string name)
            {
                return null;
            }
            
            public IOBJ IGetParent()
            {

                return null;
            }

            public string IGetType()
            {
                return "control";
            }


        }
    
}
