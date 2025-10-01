// 代码生成时间: 2025-10-01 17:01:22
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data Sharding Strategy implementation for Unity.
/// This class provides a way to divide data into shards
/// for better organization and performance.
/// </summary>
public class DataShardingStrategy
{
    private int _shardSize;
    private List<Dictionary<string, object>> _shards;

    /// <summary>
    /// Initializes a new instance of the DataShardingStrategy class.
    /// </summary>
    /// <param name="shardSize">The size of each shard.</param>
    public DataShardingStrategy(int shardSize)
    {
        _shardSize = shardSize;
        _shards = new List<Dictionary<string, object>>();
    }

    /// <summary>
    /// Adds a data item to the shards.
    /// </summary>
    /// <param name="data">The data item to add.</param>
    /// <returns>The shard index where the data was added.</returns>
    public int AddDataToShard(Dictionary<string, object> data)
    {
        if (data == null)
        {
            Debug.LogError("Data cannot be null.");
            throw new ArgumentNullException(nameof(data));
        }

        // Check if the last shard is full, and if so, create a new shard
        if (_shards.Count == 0 || _shards[_shards.Count - 1].Count >= _shardSize)
        {
            _shards.Add(new Dictionary<string, object>());
        }

        // Add data to the last shard
        _shards[_shards.Count - 1].Add(data.Count.ToString(), data);

        // Return the shard index where the data was added
        return _shards.Count - 1;
    }

    /// <summary>
    /// Retrieves a shard by its index.
    /// </summary>
    /// <param name="index">The index of the shard to retrieve.</param>
    /// <returns>The shard at the specified index, or null if the index is out of range.</returns>
    public Dictionary<string, object> GetShard(int index)
    {
        if (index < 0 || index >= _shards.Count)
        {
            Debug.LogError("Index out of range.");
            return null;
        }

        return _shards[index];
    }

    /// <summary>
    /// Clears all shards.
    /// </summary>
    public void ClearShards()
    {
        _shards.Clear();
    }
}
