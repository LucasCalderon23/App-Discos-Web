<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaDiscos.aspx.cs" Inherits="Discos_Web.ListaDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Discos</h1>
    <div class="col-4">
        <div class="mb-3">
            <label for="lblFiltro" class="form-label">Filtro Rapido:</label>
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" runat="server" ID="chkFiltro" CssClass="form-check-input"
                    AutoPostBack="true" OnCheckedChanged="chkFiltro_CheckedChanged" />
            </div>
        </div>
    </div>
    <%if (FiltroAvanzado)
        { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblCampo" runat="server" Text="Campo" />
                <asp:DropDownList ID="ddlCampo" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Titulo" />
                    <asp:ListItem Text="Genero" />
                    <asp:ListItem Text="Edicion" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblCriterio" runat="server" Text="Criterio" />
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblFiltroAvanzado" runat="server" Text="Filtro" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" AutoPostBack="true" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblEstado" runat="server" Text="Estado" />
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click"/>
                <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar" CssClass="btn btn-success" OnClick="btnLimpiarFiltro_Click"/>
            </div>
        </div>
    </div>

    <%} %>
    <asp:GridView ID="dgvListaDiscos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false"
        DataKeyNames="Id" OnSelectedIndexChanged="dgvListaDiscos_SelectedIndexChanged"
        OnPageIndexChanging="dgvListaDiscos_PageIndexChanging" AllowPaging="True" PageSize="10">
        <Columns>
            <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
            <asp:BoundField HeaderText="Genero" DataField="Genero.Descripcion" />
            <asp:BoundField HeaderText="Edicion" DataField="Edicion.Descripcion" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✅​" />
        </Columns>
    </asp:GridView>
    <a href="FormularioDisco.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
