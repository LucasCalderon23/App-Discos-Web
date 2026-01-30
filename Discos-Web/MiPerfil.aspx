<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Discos_Web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi Perfil</h1>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" runat="server" class="form-control" id="txtImagen" />
            </div>
            <asp:Image ImageUrl="https://imgs.search.brave.com/X_N2Y1fS1TO5CbzKSvt1Wsfs7lyyC_oefR6wrHHdPaU/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly91cGxv/YWQud2lraW1lZGlh/Lm9yZy93aWtpcGVk/aWEvY29tbW9ucy84/Lzg5L1BvcnRyYWl0/X1BsYWNlaG9sZGVy/LnBuZw" 
                runat="server" CssClass="img-fluid mb-3" ID="imgPerfil" />
            <asp:Button ID="btnLogOut" runat="server" Text="Cerrar sesión" CssClass="btn btn-danger" OnClick="btnLogOut_Click" />
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button Text="Guardar" runat="server" ID="btnGuardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
                <a href="/">Regresar</a>
            </div>
        </div>

    </div>
    
</asp:Content>
