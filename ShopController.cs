using System.Collections.Generic;

namespace Lab1Components
{
  public class ShopController
  {
    private ShopUserInterface View { get; set; }
    private DataRepository DataRepository { get; set; }

    public ShopController(DataRepository repository)
    {
      View = new ShopUserInterface(this);
      DataRepository = repository;
    }

    public void InitShop()
    {
      View.State = new MainMenuState(View);
      View.Start("Vitalich");
    }

    public List<Goods> GetAllGoods() => DataRepository.Goods.GetAll();
    public List<Warehouse> GetAllWarehouses() => DataRepository.Warehouses.GetAll();
    public void SelectGoods(int selectedIndex)
    {
      if (GetAllGoods().Count >= selectedIndex)
      {
        Goods item = GetAllGoods()[selectedIndex];
        item.Selected = true;
        return;
      }
      NotifyAboutError();
    }
    public void UnselectGoods(int selectedIndex)
    {
      if (GetAllGoods().Count >= selectedIndex)
      {
        Goods item = GetAllGoods()[selectedIndex];
        item.Selected = false;
        return;
      }
      NotifyAboutError();

    }
    public void SelectWarehouse(int selectedIndex)
    {
      if (GetAllWarehouses().Count >= selectedIndex)
      {
        Warehouse item = GetAllWarehouses()[selectedIndex];

        item.Selected = true;
        return;
      }
      NotifyAboutError();

    }

    public void UnselectWarehouse(int selectedIndex)
    {
      if (GetAllWarehouses().Count >= selectedIndex)
      {
        Warehouse item = GetAllWarehouses()[selectedIndex];
        item.Selected = false;
        return;
      }
      NotifyAboutError();
    }

    public Warehouse GetSelectedWareouse()
    {
      return GetAllWarehouses()
        .Find(Warehouse => Warehouse.Selected == true);
    }

    public List<Goods> GetSelectedGoods()
    {
      return GetAllGoods()
      .FindAll(goods => goods.Selected == true);
    }

    public void NotifyAboutError()
    {
      View.OperationFailed();
    }

  }
}