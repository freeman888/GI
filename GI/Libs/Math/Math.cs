﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace GI
{
    partial class Lib
    {
        public class Math_Lib : ILib
        {
            public Math_Lib()
            {
                myThing.Add("Sum", new Variable(new Math_Function_add()));
                myThing.Add("Subtract", new Variable(new Math_Function_subtrack()));
                myThing.Add("Multiply", new Variable(new Math_Function_multiply()));
                myThing.Add("Divide", new Variable(new Math_Function_divide()));
                myThing.Add("Power", new Variable(new Math_Function_power()));
                #region 取绝对值
                myThing.Add("ABS", new Variable(new Math_Function_ABS()));
                myThing.Add("Abs", new Variable(new Math_Function_ABS()));
                #endregion
                #region 比较
                myThing.Add("Bigger", new Variable(new Math_Function_CompareBig()));
                myThing.Add("Smaller", new Variable(new Math_Function_CompareSmall()));
                myThing.Add("BiggerAndEqual", new Variable(new Math_Function_CompareBigE()));
                myThing.Add("SmallerAndEqual", new Variable(new Math_Function_CompareSmallE()));
                #endregion
                #region 取余
                myThing.Add("Mod", new Variable(new Math_Function_Mod()));

                #endregion
                #region 相等
                myThing.Add("Equal", new Variable(new Math_Function_Equal()));

                #endregion

                #region 不相等
                myThing.Add("UnEqual", new Variable(new Math_Function_UnEqual()));

                #endregion


                #region 取非
                myThing.Add("Not", new Variable(new Math_Function_取非()));
                #endregion

                #region && ||
                myThing.Add("CompareAnd", new Variable(new Math_Function_CA()));

                myThing.Add("CompareOr", new Variable(new Math_Function_CO()));
                #endregion

                myThing.Add("Random", new Variable(new Math_Function_Random()));

            }


            public class Math_Function_add : Function
            {
                public Math_Function_add()
                {
                    str_xcname = "params";
                    IInformation = "add all the numbers and return the result";
                }
                public override object Run(Hashtable xc)
                {
                    var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");
                    double ret = 0;
                    foreach (Variable v in arrayList)
                    {
                        ret += Convert.ToDouble(v.value);
                    }
                    return new Variable(ret);
                }
            }
            public class Math_Function_subtrack : Function
            {
                public Math_Function_subtrack()
                {
                    IInformation = "use the first number to subtrack the second number,also subtrack all last number if have";
                    str_xcname = "params";
                }
                public override object Run(Hashtable xc)
                {
                    var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");
                    double ret = 2 * Convert.ToDouble((arrayList[0] as Variable).value);
                    foreach (Variable v in arrayList)
                    {
                        ret -= Convert.ToDouble(v.value);
                    }
                    return new Variable(ret);
                }
            }
            public class Math_Function_multiply : Function
            {
                public Math_Function_multiply()
                {
                    IInformation = "multiply all the numbers in params";
                    str_xcname = "params";
                }
                public override object Run(Hashtable xc)
                {

                    var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");
                    double ret = 1;
                    foreach (Variable v in arrayList)
                    {
                        ret *= Convert.ToDouble(v.value);
                    }
                    return new Variable(ret);
                }
            }
            public class Math_Function_divide : Function
            {
                public Math_Function_divide()
                {
                    IInformation = "devide the first number by the second and return the result";
                    str_xcname = "first,second";
                }
                public override object Run(Hashtable xc)
                {
                    double l = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "first"));
                    double r = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "second"));
                    var ret = l / r;
                    return new Variable(ret);
                }
            }
            public class Math_Function_power : Function
            {
                public Math_Function_power()
                {
                    IInformation = "Finding the nums-th power of numf";
                    str_xcname = "numf,nums";
                }
                public override object Run(Hashtable xc)
                {
                    Double num1 = Convert.ToDouble(((Variable)xc["numf"]).value);
                    int num2 = Convert.ToInt32(((Variable)xc["nums"]).value);
                    Double ret_num = num1;
                    for (int i = 1; i < num2; i++)
                        ret_num *= num1;
                    return new Variable(ret_num);
                }
            }

            public class Math_Function_ABS : Function
            {
                public Math_Function_ABS()
                {
                    IInformation = "Find absolute value";
                    str_xcname = "numf";
                }
                public override object Run(Hashtable xc)
                {
                    Double num1 = Convert.ToDouble(((Variable)xc["numf"]).value);
                    if (num1 < 0)
                    {
                        num1 = -num1;
                    }
                    return new Variable(num1);
                }
            }
            public class Math_Function_CompareBig : Function
            {
                public Math_Function_CompareBig()
                {
                    IInformation = "return if numf > nums holds";
                    str_xcname = "numf,nums";
                }
                public override object Run(Hashtable xc)
                {
                    Double num1 = Convert.ToDouble(((Variable)xc["numf"]).value);
                    Double num2 = Convert.ToDouble(((Variable)xc["nums"]).value);
                    bool ret = num1 > num2;
                    return new Variable(ret);
                }
            }
            public class Math_Function_CompareSmall : Function
            {
                public Math_Function_CompareSmall()
                {

                    IInformation = "return if numf < nums holds";
                    str_xcname = "numf,nums";
                }
                public override object Run(Hashtable xc)
                {
                    Double num1 = Convert.ToDouble(((Variable)xc["numf"]).value);
                    Double num2 = Convert.ToDouble(((Variable)xc["nums"]).value);
                    bool ret = num1 < num2;
                    return new Variable(ret);
                }
            }
            public class Math_Function_CompareBigE : Function
            {
                public Math_Function_CompareBigE()
                {

                    IInformation = "return if numf >= nums holds";
                    str_xcname = "numf,nums";
                }
                public override object Run(Hashtable xc)
                {
                    Double num1 = Convert.ToDouble(((Variable)xc["numf"]).value);
                    Double num2 = Convert.ToDouble(((Variable)xc["nums"]).value);
                    bool ret = num1 >= num2;
                    return new Variable(ret);
                }
            }
            public class Math_Function_CompareSmallE : Function
            {
                public Math_Function_CompareSmallE()
                {

                    IInformation = "return if numf <= nums holds";
                    str_xcname = "numf,nums";
                }
                public override object Run(Hashtable xc)
                {
                    Double num1 = Convert.ToDouble(((Variable)xc["numf"]).value);
                    Double num2 = Convert.ToDouble(((Variable)xc["nums"]).value);
                    bool ret = num1 <= num2;
                    return new Variable(ret);
                }
            }
            public class Math_Function_Equal : Function
            {
                public Math_Function_Equal()
                {

                    IInformation = "return if numf = nums holds";
                    str_xcname = "numf,nums";
                }
                public override object Run(Hashtable xc)
                {
                    bool ret;

                    Double num1 = Convert.ToDouble(((Variable)xc["numf"]).value);
                    Double num2 = Convert.ToDouble(((Variable)xc["nums"]).value);
                    ret = num1 == num2;

                    return new Variable(ret);
                }
            }
            public class Math_Function_UnEqual : Function
            {
                public Math_Function_UnEqual()
                {
                    IInformation = "return if numf != nums holds";
                    str_xcname = "numf,nums";
                }
                public override object Run(Hashtable xc)
                {
                    Double num1 = Convert.ToDouble(((Variable)xc["numf"]).value);
                    Double num2 = Convert.ToDouble(((Variable)xc["nums"]).value);
                    bool ret = num1 != num2;
                    return new Variable(ret);
                }
            }
            public class Math_Function_Mod : Function
            {
                public Math_Function_Mod()
                {
                    IInformation = "return if numf % nums holds";
                    str_xcname = "numf,nums";
                }
                public override object Run(Hashtable xc)
                {
                    Double num1 = Convert.ToDouble(((Variable)xc["numf"]).value);
                    Double num2 = Convert.ToDouble(((Variable)xc["nums"]).value);
                    double ret = num1 % num2;
                    return new Variable(ret);
                }
            }

            public class Math_Function_取非 : Function
            {
                public Math_Function_取非()
                {
                    IInformation = "if input true ,output false;\nif input false,output true";
                    str_xcname = "bool";
                }
                public override object Run(Hashtable xc)
                {
                    bool b = Convert.ToBoolean(Variable.GetTrueVariable<object>(xc, "bool"));
                    return new Variable(!b);
                }
            }

            public class Math_Function_CA : Function
            {
                public Math_Function_CA()
                {
                    IInformation = "if b1 is true and b2 is true , return true,or return false";
                    str_xcname = "b1,b2";
                }
                public override object Run(Hashtable xc)
                {
                    bool b1 = Convert.ToBoolean(Variable.GetTrueVariable<object>(xc, "b1"));
                    bool b2 = Convert.ToBoolean(Variable.GetTrueVariable<object>(xc, "b2"));
                    return new Variable(b1 && b2);
                }
            }

            public class Math_Function_CO : Function
            {
                public Math_Function_CO()
                {
                    IInformation = "if b1 is false and b2 is false then return false ,or return true";
                    str_xcname = "b1,b2";
                }
                public override object Run(Hashtable xc)
                {
                    bool b1 = Convert.ToBoolean(Variable.GetTrueVariable<object>(xc, "b1"));
                    bool b2 = Convert.ToBoolean(Variable.GetTrueVariable<object>(xc, "b2"));
                    return new Variable(b1 || b2);
                }
            }
            public class Math_Function_Random : Function
            {
                static Random random = new Random();
                public Math_Function_Random()
                {
                    IInformation = "get an random number from s to e";
                    str_xcname = "s,e";
                }
                public override object Run(Hashtable xc)
                {
                    return new Variable(random.Next(Convert.ToInt32(xc.GetCSVariable<object>("s")), Convert.ToInt32(xc.GetCSVariable<object>("e"))));
                }
            }



            #region
            public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>();
            public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();

            public List<string> waittoadd { get; set; } = new List<string>();
            #endregion
        }
    }
}
