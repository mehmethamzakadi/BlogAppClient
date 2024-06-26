﻿namespace BlogAppClient.Components.Layout.Sidebar;

public class SidebarData
{

    public static List<MenuItem> GetStandardMenuItems() => new()
    {
        new MenuItem(href:"/home", title: "Anasayfa", icon:"ri-home-3-fill"),
        new MenuItem(href:"/login", title: "Giriş Yap", icon:"ri-login-box-fill"),
        new MenuItem(href:"/category", title: "Kategoriler", icon:"ri-grid-fill"),
        new MenuItem(href:"/article", title: "Makaleler", icon:"ri-article-fill"),
        new MenuItem(href:"/user", title: "Kullanıcılar", icon:"ri-user-fill"),
        new MenuItem(href:"/role-management", title: "Rol Yönetimi", icon:"ri-shield-user-fill"),
        new MenuItem(href:"/logout", title: "Çıkış Yap", icon:"ri-logout-circle-fill"),
    };

    public static List<MenuItem> GetGeneralMenuItems() => new()
    {
        new(title:"Components", icon:"ri-vip-diamond-fill", suffix: new("Hot", "primary"), childMenuItems:
        [
            new MenuItem(href:"#", title:"Grid"),
            new MenuItem(title:"Layout", childMenuItems:
            [
                new MenuItem(title:"Forms", childMenuItems:
                [
                   new MenuItem(href:"#", title:"Input"),
                   new MenuItem(href:"#", title:"Select"),
                   new MenuItem(title:"More", childMenuItems:
                   [
                       new MenuItem(href:"#", title:"CheckBox"),
                       new MenuItem(href:"#", title:"Radio"),
                       new MenuItem(title:"Want more", childMenuItems:
                       [
                           new MenuItem(href:"#", title:"You made it"),
                       ]),
                   ]),
                ]),
            ]),
        ]),

        new MenuItem(title:"Charts", icon:"ri-bar-chart-2-fill", childMenuItems:
        [
            new MenuItem(href:"#", title:"Pie chart"),
            new MenuItem(href:"#", title:"Line chart"),
            new MenuItem(href:"#", title:"Bar chart"),
        ]),

        new MenuItem(title:"E-commerce", icon:"ri-shopping-cart-fill", childMenuItems:
        [
            new MenuItem(href:"#", title:"Products"),
            new MenuItem(href:"#", title:"Orders"),
            new MenuItem(href:"#", title:"Credit card"),
        ]),

        new MenuItem(title:"Maps", icon:"ri-global-fill", childMenuItems:
        [
            new MenuItem(href:"#", title:"Google maps"),
            new MenuItem(href:"#", title:"Open street map"),
        ]),
        new MenuItem(title:"Theme", icon:"ri-paint-brush-fill", childMenuItems:
        [
            new MenuItem(href:"#", title:"Dark"),
            new MenuItem(href:"#", title:"Light"),
        ]),
    };

}
