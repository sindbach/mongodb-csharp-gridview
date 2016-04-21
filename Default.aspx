<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div>
             <asp:GridView ID="CustomPaging_GridView" AutoGenerateColumns="false" runat="server" 
                 GridLines="None" HeaderStyle-BackColor="Green" AlternatingRowStyle-BackColor="Wheat"
                 PageSize="15" AllowPaging="true" AllowCustomPaging="true" OnPageIndexChanging="GridView_PageIndexChanging"
                 Width="800px" Height="300px" HeaderStyle-ForeColor="White">            

                 <Columns>

                     <asp:TemplateField HeaderText="Product Name" ItemStyle-ForeColor="Blue" HeaderStyle-HorizontalAlign="Left">
                         <ItemTemplate><%#Eval("ProductName")%></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Purchase Date" HeaderStyle-HorizontalAlign="Left"    ItemStyle-ForeColor="Blue">
                        <ItemTemplate><%#Eval("PurchaseDate") %></ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Price" HeaderStyle-HorizontalAlign="Left" ItemStyle-ForeColor="Blue">
                        <ItemTemplate><%#Convert.ToDouble(Eval(s"Price"))%></ItemTemplate>
                     </asp:TemplateField>

                </Columns>
                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
             </asp:GridView>
        </div>
    </div>

</asp:Content>
