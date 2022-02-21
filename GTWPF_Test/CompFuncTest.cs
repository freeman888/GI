using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using static GI.Function;

namespace NS_App1
{
    internal class Lib_App1 : ILib
    {
        public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>
        {
            { "Main" , new Variable(new Func_Main() )},

        };

        public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();
        public List<string> waittoadd { get; set; } = new List<string>
        {
            "System",
"IO",
"Math",
"List",

        };


        private class Func_Main : AFunction
        {
            public Func_Main()
            {
                this.Iisreffunction = false;
                this.Istr_xcname = "args";
                this.poslib = "App1";
            }

            public async override Task<object> Run(Dictionary<string, Variable> xc_1)
            {
                try
                {
                    #region var_s var num = 0;
                    
                        xc_1.Add("num", new Variable(0));
                    
                    
                    #endregion
                    #region getres_s var num = 0;
                    
                        #region arg num
                        var var_1 = new Variable(0);
                        #endregion
                        #region arg var
                        var var_2 = xc_1["num"];
                        #endregion
                        var_2.value = var_1.value;
                    
                    #endregion
                    #region var_s var i = 1;
                    
                        xc_1.Add("i", new Variable(0));
                   
                    #endregion
                    #region getres_s var i = 1;
                    
                        #region arg num
                        var var_3 = new Variable(1);
                        #endregion
                        #region arg var
                        var var_4 = xc_1["i"];
                        #endregion
                        var_4.value = var_3.value;
                    
                    #endregion
                    #region var_s var ms1 = GetTime("ms");
                    
                        xc_1.Add("ms1", new Variable(0));
                    
                    #endregion
                    #region getres_s var ms1 = GetTime("ms");
                    
                        #region arg fun
                        //funname
                        #region arg var
                        var var_7 = xc_1["GetTime"];
                        #endregion
                        //params
                        #region arg num
                        var var_8 = new Variable("ms");
                        #endregion

                        var var_9 = var_7.value as IFunction;
                        Variable var_5;
                        if (var_9.Iisasync)
                            var_5 = await var_9.IAsyncRun(Resulter.Setvariablesname(var_9.Istr_xcname, new ArrayList { var_8, }, var_9.poslib)) as Variable;
                        else
                            var_5 = var_9.IRun(Resulter.Setvariablesname(var_9.Istr_xcname, new ArrayList { var_8, }, var_9.poslib)) as Variable;
                        #endregion
                        #region arg var
                        var var_6 = xc_1["ms1"];
                        #endregion
                        var_6.value = var_5.value;
                    
                    #endregion
                    #region var_s var s1 = GetTime("s");
                    
                        xc_1.Add("s1", new Variable(0));
                    
                    #endregion
                    #region getres_s var s1 = GetTime("s");
                    
                        #region arg fun
                        //funname
                        #region arg var
                        var var_12 = xc_1["GetTime"];
                        #endregion
                        //params
                        #region arg num
                        var var_13 = new Variable("s");
                        #endregion

                        var var_14 = var_12.value as IFunction;
                        Variable var_10;
                        if (var_14.Iisasync)
                            var_10 = await var_14.IAsyncRun(Resulter.Setvariablesname(var_14.Istr_xcname, new ArrayList { var_13, }, var_14.poslib)) as Variable;
                        else
                            var_10 = var_14.IRun(Resulter.Setvariablesname(var_14.Istr_xcname, new ArrayList { var_13, }, var_14.poslib)) as Variable;
                        #endregion
                        #region arg var
                        var var_11 = xc_1["s1"];
                        #endregion
                        var_11.value = var_10.value;
                    
                    #endregion
                    #region while_s while(i< 100000):
                    
                        #region arg fun
                        //funname
                        #region arg var
                        var var_17 = xc_1["Smaller"];
                        #endregion
                        //params
                        #region arg var
                        var var_18 = xc_1["i"];
                        #endregion
                        #region arg num
                        var var_19 = new Variable(100000);
                        #endregion

                        var var_20 = var_17.value as IFunction;
                        Variable var_16;
                        if (var_20.Iisasync)
                            var_16 = await var_20.IAsyncRun(Resulter.Setvariablesname(var_20.Istr_xcname, new ArrayList { var_18, var_19, }, var_20.poslib)) as Variable;
                        else
                            var_16 = var_20.IRun(Resulter.Setvariablesname(var_20.Istr_xcname, new ArrayList { var_18, var_19, }, var_20.poslib)) as Variable;
                        #endregion
                        bool var_15 = Convert.ToBoolean((var_16).value);
                        while (var_15)
                        {
                            Dictionary<string, Variable> xc_2 = Variable.GetOwnVariables(xc_1);

                            try
                            {
                                #region getres_s num = num + Power(-1, i-1) / (2 * i - 1);
                                
                                    #region arg fun
                                    //funname
                                    #region arg var
                                    var var_23 = xc_2["Sum"];
                                    #endregion
                                    //params
                                    #region arg var
                                    var var_24 = xc_2["num"];
                                    #endregion
                                    #region arg fun
                                    //funname
                                    #region arg var
                                    var var_26 = xc_2["Divide"];
                                    #endregion
                                    //params
                                    #region arg fun
                                    //funname
                                    #region arg var
                                    var var_28 = xc_2["Power"];
                                    #endregion
                                    //params
                                    #region arg fun
                                    //funname
                                    #region arg var
                                    var var_30 = xc_2["Subtract"];
                                    #endregion
                                    //params
                                    #region arg num
                                    var var_31 = new Variable("0");
                                    #endregion
                                    #region arg num
                                    var var_32 = new Variable(1);
                                    #endregion

                                    var var_33 = var_30.value as IFunction;
                                    Variable var_29;
                                    if (var_33.Iisasync)
                                        var_29 = await var_33.IAsyncRun(Resulter.Setvariablesname(var_33.Istr_xcname, new ArrayList { var_31, var_32, }, var_33.poslib)) as Variable;
                                    else
                                        var_29 = var_33.IRun(Resulter.Setvariablesname(var_33.Istr_xcname, new ArrayList { var_31, var_32, }, var_33.poslib)) as Variable;
                                    #endregion
                                    #region arg fun
                                    //funname
                                    #region arg var
                                    var var_35 = xc_2["Subtract"];
                                    #endregion
                                    //params
                                    #region arg var
                                    var var_36 = xc_2["i"];
                                    #endregion
                                    #region arg num
                                    var var_37 = new Variable(1);
                                    #endregion

                                    var var_38 = var_35.value as IFunction;
                                    Variable var_34;
                                    if (var_38.Iisasync)
                                        var_34 = await var_38.IAsyncRun(Resulter.Setvariablesname(var_38.Istr_xcname, new ArrayList { var_36, var_37, }, var_38.poslib)) as Variable;
                                    else
                                        var_34 = var_38.IRun(Resulter.Setvariablesname(var_38.Istr_xcname, new ArrayList { var_36, var_37, }, var_38.poslib)) as Variable;
                                    #endregion

                                    var var_39 = var_28.value as IFunction;
                                    Variable var_27;
                                    if (var_39.Iisasync)
                                        var_27 = await var_39.IAsyncRun(Resulter.Setvariablesname(var_39.Istr_xcname, new ArrayList { var_29, var_34, }, var_39.poslib)) as Variable;
                                    else
                                        var_27 = var_39.IRun(Resulter.Setvariablesname(var_39.Istr_xcname, new ArrayList { var_29, var_34, }, var_39.poslib)) as Variable;
                                    #endregion
                                    #region arg fun
                                    //funname
                                    #region arg var
                                    var var_41 = xc_2["Subtract"];
                                    #endregion
                                    //params
                                    #region arg fun
                                    //funname
                                    #region arg var
                                    var var_43 = xc_2["Multiply"];
                                    #endregion
                                    //params
                                    #region arg num
                                    var var_44 = new Variable(2);
                                    #endregion
                                    #region arg var
                                    var var_45 = xc_2["i"];
                                    #endregion

                                    var var_46 = var_43.value as IFunction;
                                    Variable var_42;
                                    if (var_46.Iisasync)
                                        var_42 = await var_46.IAsyncRun(Resulter.Setvariablesname(var_46.Istr_xcname, new ArrayList { var_44, var_45, }, var_46.poslib)) as Variable;
                                    else
                                        var_42 = var_46.IRun(Resulter.Setvariablesname(var_46.Istr_xcname, new ArrayList { var_44, var_45, }, var_46.poslib)) as Variable;
                                    #endregion
                                    #region arg num
                                    var var_47 = new Variable(1);
                                    #endregion

                                    var var_48 = var_41.value as IFunction;
                                    Variable var_40;
                                    if (var_48.Iisasync)
                                        var_40 = await var_48.IAsyncRun(Resulter.Setvariablesname(var_48.Istr_xcname, new ArrayList { var_42, var_47, }, var_48.poslib)) as Variable;
                                    else
                                        var_40 = var_48.IRun(Resulter.Setvariablesname(var_48.Istr_xcname, new ArrayList { var_42, var_47, }, var_48.poslib)) as Variable;
                                    #endregion

                                    var var_49 = var_26.value as IFunction;
                                    Variable var_25;
                                    if (var_49.Iisasync)
                                        var_25 = await var_49.IAsyncRun(Resulter.Setvariablesname(var_49.Istr_xcname, new ArrayList { var_27, var_40, }, var_49.poslib)) as Variable;
                                    else
                                        var_25 = var_49.IRun(Resulter.Setvariablesname(var_49.Istr_xcname, new ArrayList { var_27, var_40, }, var_49.poslib)) as Variable;
                                    #endregion

                                    var var_50 = var_23.value as IFunction;
                                    Variable var_21;
                                    if (var_50.Iisasync)
                                        var_21 = await var_50.IAsyncRun(Resulter.Setvariablesname(var_50.Istr_xcname, new ArrayList { var_24, var_25, }, var_50.poslib)) as Variable;
                                    else
                                        var_21 = var_50.IRun(Resulter.Setvariablesname(var_50.Istr_xcname, new ArrayList { var_24, var_25, }, var_50.poslib)) as Variable;
                                    #endregion
                                    #region arg var
                                    var var_22 = xc_2["num"];
                                    #endregion
                                    var_22.value = var_21.value;
                                
                                #endregion
                                #region getres_s i = i+1;
                                
                                    #region arg fun
                                    //funname
                                    #region arg var
                                    var var_53 = xc_2["Sum"];
                                    #endregion
                                    //params
                                    #region arg var
                                    var var_54 = xc_2["i"];
                                    #endregion
                                    #region arg num
                                    var var_55 = new Variable(1);
                                    #endregion

                                    var var_56 = var_53.value as IFunction;
                                    Variable var_51;
                                    if (var_56.Iisasync)
                                        var_51 = await var_56.IAsyncRun(Resulter.Setvariablesname(var_56.Istr_xcname, new ArrayList { var_54, var_55, }, var_56.poslib)) as Variable;
                                    else
                                        var_51 = var_56.IRun(Resulter.Setvariablesname(var_56.Istr_xcname, new ArrayList { var_54, var_55, }, var_56.poslib)) as Variable;
                                    #endregion
                                    #region arg var
                                    var var_52 = xc_2["i"];
                                    #endregion
                                    var_52.value = var_51.value;
                                
                                #endregion

                            }
                            catch (Exceptions.BreakException)
                            {
                                break;
                            }
                            catch (Exceptions.ContinueException)
                            {
                                continue;
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                            #region arg fun
                            //funname
                            #region arg var
                            var var_58 = xc_1["Smaller"];
                            #endregion
                            //params
                            #region arg var
                            var var_59 = xc_1["i"];
                            #endregion
                            #region arg num
                            var var_60 = new Variable(100000);
                            #endregion

                            var var_61 = var_58.value as IFunction;
                            Variable var_57;
                            if (var_61.Iisasync)
                                var_57 = await var_61.IAsyncRun(Resulter.Setvariablesname(var_61.Istr_xcname, new ArrayList { var_59, var_60, }, var_61.poslib)) as Variable;
                            else
                                var_57 = var_61.IRun(Resulter.Setvariablesname(var_61.Istr_xcname, new ArrayList { var_59, var_60, }, var_61.poslib)) as Variable;
                            #endregion
                            var_15 = Convert.ToBoolean((var_57).value);
                        }

                    
                    #endregion
                    #region var_s var ms2 = GetTime("ms");
                    
                        xc_1.Add("ms2", new Variable(0));
                    
                    #endregion
                    #region getres_s var ms2 = GetTime("ms");
                    
                        #region arg fun
                        //funname
                        #region arg var
                        var var_64 = xc_1["GetTime"];
                        #endregion
                        //params
                        #region arg num
                        var var_65 = new Variable("ms");
                        #endregion

                        var var_66 = var_64.value as IFunction;
                        Variable var_62;
                        if (var_66.Iisasync)
                            var_62 = await var_66.IAsyncRun(Resulter.Setvariablesname(var_66.Istr_xcname, new ArrayList { var_65, }, var_66.poslib)) as Variable;
                        else
                            var_62 = var_66.IRun(Resulter.Setvariablesname(var_66.Istr_xcname, new ArrayList { var_65, }, var_66.poslib)) as Variable;
                        #endregion
                        #region arg var
                        var var_63 = xc_1["ms2"];
                        #endregion
                        var_63.value = var_62.value;
                    
                    #endregion
                    #region var_s var s2 = GetTime("s");
                    
                        xc_1.Add("s2", new Variable(0));
                    
                    #endregion
                    #region getres_s var s2 = GetTime("s");
                    
                        #region arg fun
                        //funname
                        #region arg var
                        var var_69 = xc_1["GetTime"];
                        #endregion
                        //params
                        #region arg num
                        var var_70 = new Variable("s");
                        #endregion

                        var var_71 = var_69.value as IFunction;
                        Variable var_67;
                        if (var_71.Iisasync)
                            var_67 = await var_71.IAsyncRun(Resulter.Setvariablesname(var_71.Istr_xcname, new ArrayList { var_70, }, var_71.poslib)) as Variable;
                        else
                            var_67 = var_71.IRun(Resulter.Setvariablesname(var_71.Istr_xcname, new ArrayList { var_70, }, var_71.poslib)) as Variable;
                        #endregion
                        #region arg var
                        var var_68 = xc_1["s2"];
                        #endregion
                        var_68.value = var_67.value;
                    
                    #endregion
                    #region usefun_s WriteLine(4*num);
                    
                        #region arg fun
                        //funname
                        #region arg var
                        var var_73 = xc_1["WriteLine"];
                        #endregion
                        //params
                        #region arg fun
                        //funname
                        #region arg var
                        var var_75 = xc_1["Multiply"];
                        #endregion
                        //params
                        #region arg num
                        var var_76 = new Variable(4);
                        #endregion
                        #region arg var
                        var var_77 = xc_1["num"];
                        #endregion

                        var var_78 = var_75.value as IFunction;
                        Variable var_74;
                        if (var_78.Iisasync)
                            var_74 = await var_78.IAsyncRun(Resulter.Setvariablesname(var_78.Istr_xcname, new ArrayList { var_76, var_77, }, var_78.poslib)) as Variable;
                        else
                            var_74 = var_78.IRun(Resulter.Setvariablesname(var_78.Istr_xcname, new ArrayList { var_76, var_77, }, var_78.poslib)) as Variable;
                        #endregion

                        var var_79 = var_73.value as IFunction;
                        Variable var_72;
                        if (var_79.Iisasync)
                            var_72 = await var_79.IAsyncRun(Resulter.Setvariablesname(var_79.Istr_xcname, new ArrayList { var_74, }, var_79.poslib)) as Variable;
                        else
                            var_72 = var_79.IRun(Resulter.Setvariablesname(var_79.Istr_xcname, new ArrayList { var_74, }, var_79.poslib)) as Variable;
                        #endregion
                    
                    #endregion
                    #region usefun_s WriteLine(1000*(s2-s1) + (ms2-ms1));
                    
                        #region arg fun
                        //funname
                        #region arg var
                        var var_81 = xc_1["WriteLine"];
                        #endregion
                        //params
                        #region arg fun
                        //funname
                        #region arg var
                        var var_83 = xc_1["Sum"];
                        #endregion
                        //params
                        #region arg fun
                        //funname
                        #region arg var
                        var var_85 = xc_1["Multiply"];
                        #endregion
                        //params
                        #region arg num
                        var var_86 = new Variable(1000);
                        #endregion
                        #region arg fun
                        //funname
                        #region arg var
                        var var_88 = xc_1["Subtract"];
                        #endregion
                        //params
                        #region arg var
                        var var_89 = xc_1["s2"];
                        #endregion
                        #region arg var
                        var var_90 = xc_1["s1"];
                        #endregion

                        var var_91 = var_88.value as IFunction;
                        Variable var_87;
                        if (var_91.Iisasync)
                            var_87 = await var_91.IAsyncRun(Resulter.Setvariablesname(var_91.Istr_xcname, new ArrayList { var_89, var_90, }, var_91.poslib)) as Variable;
                        else
                            var_87 = var_91.IRun(Resulter.Setvariablesname(var_91.Istr_xcname, new ArrayList { var_89, var_90, }, var_91.poslib)) as Variable;
                        #endregion

                        var var_92 = var_85.value as IFunction;
                        Variable var_84;
                        if (var_92.Iisasync)
                            var_84 = await var_92.IAsyncRun(Resulter.Setvariablesname(var_92.Istr_xcname, new ArrayList { var_86, var_87, }, var_92.poslib)) as Variable;
                        else
                            var_84 = var_92.IRun(Resulter.Setvariablesname(var_92.Istr_xcname, new ArrayList { var_86, var_87, }, var_92.poslib)) as Variable;
                        #endregion
                        #region arg fun
                        //funname
                        #region arg var
                        var var_94 = xc_1["Subtract"];
                        #endregion
                        //params
                        #region arg var
                        var var_95 = xc_1["ms2"];
                        #endregion
                        #region arg var
                        var var_96 = xc_1["ms1"];
                        #endregion

                        var var_97 = var_94.value as IFunction;
                        Variable var_93;
                        if (var_97.Iisasync)
                            var_93 = await var_97.IAsyncRun(Resulter.Setvariablesname(var_97.Istr_xcname, new ArrayList { var_95, var_96, }, var_97.poslib)) as Variable;
                        else
                            var_93 = var_97.IRun(Resulter.Setvariablesname(var_97.Istr_xcname, new ArrayList { var_95, var_96, }, var_97.poslib)) as Variable;
                        #endregion

                        var var_98 = var_83.value as IFunction;
                        Variable var_82;
                        if (var_98.Iisasync)
                            var_82 = await var_98.IAsyncRun(Resulter.Setvariablesname(var_98.Istr_xcname, new ArrayList { var_84, var_93, }, var_98.poslib)) as Variable;
                        else
                            var_82 = var_98.IRun(Resulter.Setvariablesname(var_98.Istr_xcname, new ArrayList { var_84, var_93, }, var_98.poslib)) as Variable;
                        #endregion

                        var var_99 = var_81.value as IFunction;
                        Variable var_80;
                        if (var_99.Iisasync)
                            var_80 = await var_99.IAsyncRun(Resulter.Setvariablesname(var_99.Istr_xcname, new ArrayList { var_82, }, var_99.poslib)) as Variable;
                        else
                            var_80 = var_99.IRun(Resulter.Setvariablesname(var_99.Istr_xcname, new ArrayList { var_82, }, var_99.poslib)) as Variable;
                        #endregion
                    
                    #endregion

                }
                catch (Exceptions.ReturnException ex)
                {
                    return ex.toreturn;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return new Variable(0);
            }
        }


    }
}
