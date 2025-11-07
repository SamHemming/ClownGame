using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory single;

    public Button combineButton;

    public List<Item> items = new();

	public bool hattara = false;
	public bool vaha = false;
	public bool purkka = false;
	public bool purkki = false;
	public bool cutter = false;
	public bool ticket = false;
	public bool liima = false;
    public GameObject objhattara;
    public GameObject objvaha;
    public GameObject objpurkka;
    public GameObject objpurkki;
    public GameObject objcutter;
    public GameObject objticket;
	public GameObject objliima;

	void Start()
    {
        if (single == null)
            single = this;
        else Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

        combineButton.onClick.AddListener(Combine);
    }

    public void Add(Item item)
    {
        items.Add(item);

		if (item.name == "hattara")
		{
			hattara = true;
			objhattara.SetActive(true);
		}
		if (item.name == "vaha")
		{
			vaha = true;
			objvaha.SetActive(true);
		}
		if (item.name == "purkka")
		{
			purkka = true;
			objpurkka.SetActive(true);
		}
		if (item.name == "purkki")
		{
			purkki = true;
			objpurkki.SetActive(true);
		}
		if (item.name == "cutter")
		{
			cutter = true;
			objcutter.SetActive(true);
		}
		if (item.name == "ticket")
		{
			ticket = true;
			objticket.SetActive(true);
		}
		if (item.name == "liima")
		{
			liima = true;
			objliima.SetActive(true);
		}
	}

    public void Remove(Item item)
    {
        items.Remove(item);

		if (item.name == "hattara")
		{
			hattara = false;
			objhattara.SetActive(false);
		}
		if (item.name == "vaha")
		{
			vaha = false;
			objvaha.SetActive(false);
		}
		if (item.name == "purkka")
		{
			purkka = false;
			objpurkka.SetActive(false);
		}
		if (item.name == "purkki")
		{
			purkki = false;
			objpurkki.SetActive(false);
		}
		if (item.name == "cutter")
		{
			cutter = false;
			objcutter.SetActive(false);
		}
		if (item.name == "ticket")
		{
			ticket = false;
			objticket.SetActive(false);
		}
		if (item.name == "liima")
		{
			liima = false;
			objliima.SetActive(false);
		}
	}

	public void GetHattara()
	{
		hattara = true;
		objhattara.SetActive(true);
		items.Add(new Item("hattara"));
	}

    public void Combine()
    {
        if(items.Contains(new Item("liima")) && items.Contains(new Item("purkka")) && items.Contains(new Item("purkki")) && items.Contains(new Item("hattara")))
        {
            items.Add(new Item("vaha"));
            vaha = true;
            objvaha.SetActive(true);

            items.Remove(new Item("liima"));
            liima = false ;
            objliima.SetActive(false);

            items.Remove(new Item("purkka"));
            purkka = false ;
            objpurkka.SetActive(false);

            items.Remove(new Item("purkki"));
            purkki = false ;
            objpurkki.SetActive(false);

            items.Remove(new Item("hattara"));
            hattara = false ;
            objhattara.SetActive(false);
        }
    }

}
