﻿using System.Collections.Generic;
using System;
using UnityEngine;
namespace Cosmos.Resource
{
    /// <summary>
    /// 资源包，AssetBundle；
    /// 存储AssetBundle信息；
    /// </summary>
    [Serializable]
    public class ResourceBundle : IEquatable<ResourceBundle>
    {
        [SerializeField]
        string bundleName;
        [SerializeField]
        string bundlePath;
        [SerializeField]
        string bundleKey;
        [SerializeField]
        List<string> dependentList = new List<string>();
        [SerializeField]
        List<ResourceObject> resourceObjectList = new List<ResourceObject>();
        /// <summary>
        /// 资源包的名称，AsseBundleName；
        /// </summary>
        public string BundleName
        {
            get { return bundleName; }
            set
            {
                var srcValue = value;
                if (!string.IsNullOrEmpty(srcValue))
                {
                    srcValue = ResourceUtility.BundleNameFilter(srcValue);
                }
                bundleName = srcValue;
            }
        }
        /// <summary>
        /// AB加载时候使用的名称；
        /// </summary>
        public string BundleKey
        {
            get { return bundleKey; }
            set { bundleKey = value; }
        }
        /// <summary>
        /// AB包在Assets目录下的地址；
        /// </summary>
        public string BundlePath
        {
            get { return bundlePath; }
            set { bundlePath = value; }
        }
        /// <summary>
        /// 资源的依赖项；
        /// </summary>
        public List<string> DependentList
        {
            get
            {
                if (dependentList == null)
                    dependentList = new List<string>();
                return dependentList;
            }
            set { dependentList = value; }
        }
        /// <summary>
        /// 资源对象列表；
        /// </summary>
        public List<ResourceObject> ResourceObjectList
        {
            get
            {
                if (resourceObjectList == null)
                    resourceObjectList = new List<ResourceObject>();
                return resourceObjectList;
            }
            set { resourceObjectList = value; }
        }
        public bool Equals(ResourceBundle other)
        {
            return other.BundleName == this.BundleName;
        }
        public override int GetHashCode()
        {
            return $"{bundleName}".GetHashCode();
        }
    }
}
