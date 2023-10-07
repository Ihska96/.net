<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrollmentForm.aspx.cs" Inherits="WebApp6Aug.EnrollmentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
        <div>
            <h1>Enrollment-Form</h1>
            <table>
                <tr>
                    <td>
                     NAME:
                    </td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                     FATHER_NAME:
                    </td>
                    <td>
                        <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td>
                    MOTHER_NAME:
                    </td>
                    <td>
                        <asp:TextBox ID="txtmname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td>
                     Gender:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                        
                        </asp:RadioButtonList>
                    </td>
                </tr>
                     <tr>
                    <td>
                      Board:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblboard" runat="server" RepeatColumns="3">
                          
                        </asp:RadioButtonList>
                    </td>
                </tr>
                    <tr>
                    <td>
                     Class:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddclass" runat="server">
                             
                        </asp:DropDownList>
                    </td>
                </tr>
                    <tr>
                    <td>
                        Stream:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddstream" runat="server" >
                            
                        </asp:DropDownList>               

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button id="btnSave"  Text="Save" runat="server" OnClick="btnSave_Click"/>
                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td></td>
                   <td>
                       <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false"  OnRowCommand="grd_RowCommand" >
                          <Columns>
                             <asp:TemplateField HeaderText="Student_Name">
                             <ItemTemplate>
                                 <%#Eval("NAME") %>
                                 
                             </ItemTemplate>
                             </asp:TemplateField>

                           <asp:TemplateField HeaderText="Fatrher_Name">
                             <ItemTemplate>
                                 <%#Eval("FATHER_NAME") %>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Mother_Name">
                             <ItemTemplate>
                                 <%#Eval("MOTHER_NAME") %>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Gender">
                             <ItemTemplate>
                                 <%#Eval("genderName") %>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Board">
                             <ItemTemplate>
                                <%# Eval("bvalue") %>
                             </ItemTemplate>
                         </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="Class">
                             <ItemTemplate>
                                  <%# Eval("cname") %> 
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Stream">
                             <ItemTemplate>
                                 <%# Eval("sname")%>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Actions">
                             <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete"  CommandName="del" CommandArgument='<%#Eval("EnrollNo") %>'/>
                                <asp:LinkButton ID="Edi" runat="server" Text="Edit" CommandName="edi" CommandArgument='<%#Eval("EnrollNo")%>'/>
                             </ItemTemplate>
                         </asp:TemplateField>

                      
                     </Columns>
                     </asp:GridView></td>
                    
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
