using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using System.Collections.Generic;
using System;

namespace ToDo.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/items")]
    public ActionResult Index()
    {
        // Item newItem = new Item(Request.Query["new-item"]);
        // newItem.Save();
        // List<Item> result = new List<Item>();
        // return View(result);
        List<Item> allItems = Item.GetAll();
        return View(allItems);
    }

    [HttpGet("/items/new")]
    public ActionResult CreateForm()
    {
        return View();
    }
    [HttpPost("/items")]
    public ActionResult Create()
    {
      Item newItem = new Item (Request.Form["newitem"]);
      // newItem.Save();
      List<Item> allItems = Item.GetAll();
      return View("Index", allItems);
    }
    [HttpGet("/items/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
        Item thisItem = Item.Find(id);
        return View(thisItem);
    }
    [HttpPost("/items/{id}/update")]
    public ActionResult Update(int id)
    {
        Item thisItem = Item.Find(id);
        thisItem.Edit(Request.Form["newname"]);
        return RedirectToAction("Index");
    }

    [HttpGet("/items/{id}/delete")]
    public ActionResult Delete(int id)
    {
        Item thisItem = Item.Find(id);
        thisItem.Delete();
        return RedirectToAction("Index");
    }
    // [HttpPost("/items/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Item.ClearAll();
    //   return View();
    // }
    // [HttpGet("/items/{id}")]
    // public ActionResult Details(int id)
    // {
    //     Item item = Item.Find(id);
    //     return View(item);
    // }
  }
}
