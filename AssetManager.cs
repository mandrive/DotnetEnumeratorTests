using System.Collections.Generic;
using System.Linq;

public class AssetManager
{
    private IEnumerable<CustomAsset> _customAssets;
    private IList<CustomAsset> _customAssetsList;
    private readonly InitializationCollection initializationCollection;

    public AssetManager(InitializationCollection initializationCollection)
    {
        this.initializationCollection = initializationCollection;
    }

    private IList<CustomAsset> BuildAssetsCollection(int howManyAssets) {
        var result = new List<CustomAsset>();
        for (int i = 0; i < howManyAssets; i++)
        {
            result.Add(new CustomAsset { Name = "Name + " + i.ToString(), Val = i });
        }

        return result;
    }

    private IEnumerable<CustomAsset> BuildEnumerableCollectionOfCustomAssets(IList<CustomAsset> items) {
        var result = (from item in items
            select new CustomAsset {
                Name = item.Name,
                Val = item.Val
            });

        return result;
    }

    private IEnumerable<CustomAsset> BuildEnumerableCollectionButAsListOfCustomAssets(IList<CustomAsset> items) {
        var result = (from item in items
            select new CustomAsset {
                Name = item.Name,
                Val = item.Val
            }).ToList();

        return result;
    }

    private IEnumerable<CustomAsset> BuildEnumerableCollectionButAsArrayOfCustomAssets(IList<CustomAsset> items) {
        var result = (from item in items
            select new CustomAsset {
                Name = item.Name,
                Val = item.Val
            }).ToArray();

        return result;
    }

    private IEnumerable<CustomAsset> BuildEnumerableCollectionButAsQueryableOfCustomAssets(IList<CustomAsset> items) {
        var result = (from item in items
            select new CustomAsset {
                Name = item.Name,
                Val = item.Val
            }).AsQueryable();

        return result;
    }

    private void Initialize(InitializationCollection initCollection) {
        _customAssetsList = BuildAssetsCollection(10);

        switch(initCollection) {
            case InitializationCollection.Enumerable:
                _customAssets = BuildEnumerableCollectionOfCustomAssets(_customAssetsList);        
            break;
            case InitializationCollection.List:
                _customAssets = BuildEnumerableCollectionButAsListOfCustomAssets(_customAssetsList);
            break;
            case InitializationCollection.Array:
                _customAssets = _customAssets = BuildEnumerableCollectionButAsArrayOfCustomAssets(_customAssetsList);
            break;
            case InitializationCollection.Queryable:
                _customAssets = _customAssets = BuildEnumerableCollectionButAsQueryableOfCustomAssets(_customAssetsList);
            break;
        }
    }

    public IList<CustomAsset> UpdatePropertyByResolvingEnumerableInForeachAndSecondTimeInReturn() {
        if (_customAssets == null || _customAssetsList == null) {
            Initialize(initializationCollection);
        }

        foreach(var item in _customAssets.ToList()) {
            item.Name = "BetterName + " + item.Val;
        }

        return _customAssets.ToList();
    }

    public IList<CustomAsset> UpdatePropertyByResolvingEnumerableBeforeAndInForeachAndInReturn() {
        if (_customAssets == null || _customAssetsList == null) {
            Initialize(initializationCollection);
        }

        var betterList = _customAssets.ToList();

        foreach(var item in betterList.ToList()) {
            item.Name = "BetterName + " + item.Val;
        }

        return betterList.ToList();
    }
}