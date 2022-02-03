namespace GI
{
    public interface IOBJ
    {
        string IGetType();
        string ToString();

        /// <summary>
        /// Gasoline类将不用返回实例
        /// </summary>
        /// <returns>Gasoline类返回null，请先用IGetParent获取类型</returns>
        object IGetCSValue();

        Variable IGetMember(string name);

        /// <summary>
        /// 返回null为没有父对象
        /// </summary>
        /// <returns>父对象</returns>
        IOBJ IGetParent();



    }
}
