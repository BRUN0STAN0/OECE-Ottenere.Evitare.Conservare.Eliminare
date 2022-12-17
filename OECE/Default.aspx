<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OECE.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<link href="./style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="d-flex flex-column justify-content-center align-items-center">
                <span class="w-100" data-bs-toggle="modal" data-bs-target="#exampleModal">
                <asp:Button ID="Button_AggiungiNuovaVoce" runat="server" Text="Aggiungi una nuova voce" OnClientClick="return false;" CssClass="w-100 text-center btn btn-warning" />
                </span>
                    <table class="w-100" style="border: 1px solid black; height: 90vh">
                    <tr>
                        <td class="border border-2 bg-secondary text-white fw-bold w-50 text-center" style="height: 30px">Ottenere</td>
                        <td class="border border-2 bg-secondary text-white fw-bold w-50 text-center" style="height: 30px">Conservare</td>
                    </tr>
                    <tr>
                        <td class="border border-2 h-50 ">
                            <div class=" d-flex flex-wrap ">
                                <asp:Repeater ID="Repeater_Ottenere" ItemType="OECE.OECE" runat="server">
                                    <ItemTemplate>
                                          <asp:Button runat="server" ID="Button_DeleteVoceFromDB" OnClick="Button_DeleteVoceFromDB_Click" Text="<%# Item.Item %>" CssClass="btn btn-light" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                        <td class="border border-2 h-50 ">
                            <div class=" d-flex flex-wrap ">
                                <asp:Repeater ID="Repeater_Conservare" ItemType="OECE.OECE" runat="server">
                                    <ItemTemplate>
                                         <asp:Button runat="server" ID="Button_DeleteVoceFromDB" OnClick="Button_DeleteVoceFromDB_Click" Text="<%# Item.Item %>" CssClass="btn btn-light" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="border border-2 bg-dark text-white fw-bold w-50 text-center" style="height: 30px">Evitare</td>
                        <td class="border border-2 bg-dark text-white fw-bold w-50 text-center" style="height: 30px">Eliminare</td>
                    </tr>
                    <tr>
                        <td class="border border-2 h-50 ">
                            <div class=" d-flex flex-wrap ">
                                <asp:Repeater ID="Repeater_Evitare" ItemType="OECE.OECE" runat="server">
                                    <ItemTemplate>
                                         <asp:Button runat="server" ID="Button_DeleteVoceFromDB" OnClick="Button_DeleteVoceFromDB_Click" Text="<%# Item.Item %>" CssClass="btn btn-light" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                        <td class="border border-2 h-50 ">
                           <div class=" d-flex flex-wrap ">
                                <asp:Repeater ID="Repeater_Eliminare" ItemType="OECE.OECE" runat="server">
                                    <ItemTemplate>
                                         <asp:Button runat="server" ID="Button_DeleteVoceFromDB" OnClick="Button_DeleteVoceFromDB_Click" Text="<%# Item.Item %>" CssClass="btn btn-light" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:Label runat="server" ID="Label_ERROR"></asp:Label>
            </div>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="exampleModalLabel">Aggiungi una nuova voce</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:TextBox ID="TextBox_AggiungiNuovaVoce" CssClass="form-control" placeholder="Inserisci una nuova voce" runat="server"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <asp:CheckBox ID="CheckBox_CeLho" runat="server" /> Ce l'ho?
                        <asp:CheckBox ID="CheckBox_LoVoglio" runat="server" /> Lo voglio?
                        <asp:Button ID="Button_InviaAlDatabase" OnClick="Button_InviaAlDatabase_Click" CssClass="btn btn-warning" runat="server" Text="Invia" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="Scripts/bootstrap.min.js"></script>
</html>
