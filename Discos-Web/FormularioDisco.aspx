<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioDisco.aspx.cs" Inherits="Discos_Web.FormularioDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="lblId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="lblTitulo" class="form-label">Titulo</label>
                <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="lblFecha" class="form-label">Fecha de Lanzamiento</label>
                <asp:TextBox runat="server" TextMode="Date" ID="txtFecha" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="lblCanciones" class="form-label">Cantidad de Canciones</label>
                <asp:TextBox runat="server" ID="txtCanciones" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="lblGenero" class="form-label">Genero</label>
                <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="lblEdicion" class="form-label">Edicion</label>
                <asp:DropDownList ID="ddlEdicion" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-primary" OnClick="btnAceptar_Click" />
                <a href="ListaDiscos.aspx">Cancelar</a>
            </div>
        </div>

        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <label for="lblUrlImagenTapa" class="form-label">URL Imagen Tapa</label>
                        <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://imgs.search.brave.com/1qZ1xZHKx_mRy0qHVnLPv0oVuMyN_P5s52GP9bd1m10/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTEy/ODgyNjg4NC92ZWN0/b3Ivbm8taW1hZ2Ut/dmVjdG9yLXN5bWJv/bC1taXNzaW5nLWF2/YWlsYWJsZS1pY29u/LW5vLWdhbGxlcnkt/Zm9yLXRoaXMtbW9t/ZW50LmpwZz9zPTYx/Mng2MTImdz0wJms9/MjAmYz0zOTBlNzZ6/Tl9USjdIWkhKcG5J/N2pObDdVQnBPM1VQ/N2hwUjJtZUUxUWQ0/PQ"
                        runat="server" ID="imgDisco" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row">
            <%if (Request.QueryString["id"] != null)
                { %>
            <div class="col-6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminar_Click"/>
                            <asp:Button ID="btnDesactivar" runat="server" Text="Desactivar" class="btn btn-warning" OnClick="btnDesactivar_Click" />
                        </div>
                        <%if (Confirmacion) { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar eliminacion" ID="chkConfirmacion" runat="server" />
                            <asp:Button ID="btnConfirmacion" runat="server" Text="Confirmar" class="btn btn-outline-danger" OnClick="btnConfirmacion_Click"/>
                        </div>
                        <% }%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <%} %>
        </div>

    </div>
</asp:Content>
