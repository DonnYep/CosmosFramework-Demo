﻿namespace Cosmos.DataNode
{
    //================================================
    /*
    *1、数据存储模块。可以使用几种方式记录数据：
    *    Data/SubData/SubDataA
    *    Data\SubData\SubDataA
    *    Data.SubData.SubDataA
    *    此为树状结构，又如有数据为Data/SubData/SubDataB，则表示为：
    *    Data/SubData/ 下的两个数据，分别为SubDataA与SubDataB。
    *    写法上使用何种分隔符并无区别。分隔符为 string[] { ".", "/", "\\" };
    */
    //================================================
    public interface IDataNodeManager :IModuleManager, IModuleInstance
    {
        /// <summary>
        /// 获取根数据结点；
        /// </summary>
        IDataNode Root { get; }
        /// <summary>
        /// 根据类型获取数据结点的数据；
        /// </summary>
        /// <typeparam name="T">要获取的数据类型</typeparam>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <returns>指定类型的数据</returns>
        T GetData<T>(string path) where T : IDataVariable;
        /// <summary>
        /// 获取数据结点的数据；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <returns>数据结点的数据</returns>
        IDataVariable GetData(string path);
        /// <summary>
        /// 根据类型获取数据结点的数据；
        /// </summary>
        /// <typeparam name="T">要获取的数据类型</typeparam>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <param name="node">查找起始结点</param>
        /// <returns>指定类型的数据</returns>
        T GetData<T>(string path, IDataNode node) where T : IDataVariable;
        /// <summary>
        /// 获取数据结点的数据；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <param name="node">查找起始结点</param>
        /// <returns>数据结点的数据</returns>
        IDataVariable GetData(string path, IDataNode node);
        /// <summary>
        /// 设置数据结点的数据；
        /// </summary>
        /// <typeparam name="T">要设置的数据类型</typeparam>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <param name="data">要设置的数据</param>
        void SetData<T>(string path, T data) where T : IDataVariable;
        /// <summary>
        /// 设置数据结点的数据；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <param name="data">要设置的数据</param>
        void SetData(string path, IDataVariable data);
        /// <summary>
        /// 设置数据结点的数据；
        /// </summary>
        /// <typeparam name="T">要设置的数据类型</typeparam>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <param name="data">要设置的数据</param>
        /// <param name="node">查找起始结点</param>
        void SetData<T>(string path, T data, IDataNode node) where T : IDataVariable;
        /// <summary>
        /// 设置数据结点的数据；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <param name="data">要设置的数据</param>
        /// <param name="node">查找起始结点</param>
        void SetData(string path, IDataVariable data, IDataNode node);
        /// <summary>
        /// 获取数据结点；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <returns>指定位置的数据结点，如果没有找到，则返回空</returns>
        IDataNode GetNode(string path);
        /// <summary>
        /// 获取数据结点；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <param name="node">查找起始结点</param>
        /// <returns>指定位置的数据结点，如果没有找到，则返回空</returns>
        IDataNode GetNode(string path, IDataNode node);
        /// <summary>
        /// 获取或增加数据结点；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <returns>指定位置的数据结点，如果没有找到，则创建相应的数据结点</returns>
        IDataNode GetOrAddNode(string path);
        /// <summary>
        /// 获取或增加数据结点；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <param name="node">查找起始结点</param>
        /// <returns>指定位置的数据结点，如果没有找到，则增加相应的数据结点</returns>
        IDataNode GetOrAddNode(string path, IDataNode node);
        /// <summary>
        /// 移除数据结点；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        void RemoveNode(string path);
        /// <summary>
        /// 移除数据结点；
        /// </summary>
        /// <param name="path">相对于 node 的查找路径</param>
        /// <param name="node">查找起始结点</param>
        void RemoveNode(string path, IDataNode node);
        /// <summary>
        /// 移除所有数据结点；
        /// </summary>
        void ClearNodes();
    }
}
