<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaDiscos.aspx.cs" Inherits="Discos_Web.ListaDiscos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Discos</h1>
    <asp:GridView ID="dgvListaDiscos" runat="server" CssClass="table" AutoGenerateColumns="false" 
        DataKeyNames="Id" OnSelectedIndexChanged="dgvListaDiscos_SelectedIndexChanged"
        OnPageIndexChanging="dgvListaDiscos_PageIndexChanging" AllowPaging="True" PageSize="10">
        <Columns>
            <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
            <asp:BoundField HeaderText="Genero" DataField="Genero.Descripcion" />
            <asp:BoundField HeaderText="Edicion" DataField="Edicion.Descripcion" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✅​" />
        </Columns>
    </asp:GridView>
    <a href="FormularioDisco.aspx" Class="btn btn-primary">Agregar</a>
</asp:Content>
