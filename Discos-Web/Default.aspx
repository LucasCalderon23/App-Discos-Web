<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Discos_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola!</h1>
    <h3>Esta es la parte web de los discos...</h3>

    <div class="row row-cols-1 row-cols-md-3 g-4">

    <%foreach (Dominio.Discos disco in listaDiscos)
        { %>
            <div class="col">
                <div class="card h-100">
                    <img src="<%:disco.UrlImagenTapa %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%:disco.Titulo %></h5>
                        <p class="card-text"><%:disco.Cant_Canciones %> canciones</p>
                        <a href="DetalleDisco.aspx?id=<%:disco.Id %>">Ver Detalle</a>
                    </div>
                </div>
            </div>
        <%}%>
        </div>


</asp:Content>
