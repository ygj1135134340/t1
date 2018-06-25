<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="JournalList.aspx.cs" Inherits="bogleaspx_JournalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 779px;
            height: 74px;
        }
        .style4
        {
            width: 235px;
        }
         hl1{

	  font-family:黑体;
	position:absolute;
	
	color:White;
	left:140px;
	top:680px;
	width:880px;
	height:33px;
	font-size:20px;
	background-color:#1b1b1b;
}
          #j1{

	  font-family:黑体;
	position:absolute;
	color:White;
	left:195px;
	top:750px;
	width:680px;
	height:33px;
	font-size:15px;
}
 #j2{

	  font-family:黑体;
	position:absolute;
	color:White;
	left:195px;
	top:720px;
	width:680px;
	height:33px;
	font-size:15px;
}
#jb1{

	  font-family:黑体;
	position:absolute;
	color:White;
	left:195px;
	top:420px;
	width:680px;
	height:33px;
	font-size:15px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mineBolge" Runat="Server">

<hl1 align="center">日  志</hl1>



    <div id="j2">
        
            <asp:DataList ID="dljourer" runat="server" Width="800px" Height="630px" 
             RepeatColumns="2" RepeatLayout="Flow" DataKeyField="titleID" 
             ondeletecommand="dljourer_DeleteCommand" 
             oneditcommand="dljourer_EditCommand" 
             onitemdatabound="dljourer_ItemDataBound" 
             onitemcommand="dljourer_ItemCommand"  >
                <ItemTemplate>
                    <table class="style1">
                        <tr>
                            <td colspan="5">
                                <asp:LinkButton ID="LinkButton18" runat="server" 
                                    CommandArgument='<%# Eval("titleID") %>' CommandName="name" 
                                    Text='<%# Eval("title") %>' onclick="LinkButton18_Click" ForeColor="Red"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("createtime") %>' ForeColor="White"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:LinkButton ID="LinkButton17" runat="server" Text='<%# Eval("name") %>' 
                                    CommandName="lbtnUserName" CommandArgument='<%# Eval("name") %>' 
                                    onclick="LinkButton17_Click" ForeColor="White"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("digests") %>' ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>

                                    <asp:Label ID="Label9" runat="server" Text="点击数:" ForeColor="White"></asp:Label>
                                    <asp:LinkButton ID="lbtnClicks" runat="server" CommandName="lbltnClick" 
                                        Text='<%# Eval("Clicks") %>' ForeColor="Red"></asp:LinkButton>

                                </div>
                                </td>
                            <td>
                               <div id="lbtnVisitord">
                                   <asp:Label ID="Label1" runat="server" Text="评论:" ForeColor="White"></asp:Label> 
                                   <asp:LinkButton ID="lbtnVisitor" runat="server" CommandName="lbtnCommnent" 
                                       Text='<%# Eval("commentnum") %>' ForeColor="Red"></asp:LinkButton>
                               </div></td>
                            <td class="style4">
                               <div>
                                   <asp:Label ID="Label7" runat="server" Text="所属分类:" ForeColor="White"></asp:Label>
                                   <asp:Label ID="Label8" runat="server" Text='<%# Eval("sort") %>' ForeColor="Red"></asp:Label>
                               </div>
                               </td>
                            <td>
                               <div id="lbtneditord">
                                   <asp:LinkButton ID="lbtneditor" runat="server" CommandName="UpdateClick"  
                                       Visible="False" CommandArgument='<%# Eval("titleID") %>' ForeColor="White">编辑</asp:LinkButton>
                               </div>
                               </td>
                            <td>
                               <div id="lbtndeleted">
                                   <asp:LinkButton ID="lbtndelete" runat="server" CommandName="delete" 
                                       Visible="False" ForeColor="White">删除</asp:LinkButton>
                               </div>
                               </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:Label ID="lbltitlieId" runat="server" Text='<%# Eval("titleID") %>' 
                                    Visible="False"></asp:Label>
                                <asp:Label ID="lbliscomment" runat="server" Text='<%# Eval("iscomment") %>' 
                                    Visible="False"></asp:Label>
                                <asp:Label ID="lblusername" runat="server" Text='<%# Eval("username") %>' 
                                    Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                </ItemTemplate>
               <%-- <SelectedItemTemplate>
                    <hr />
                </SelectedItemTemplate>--%>
                <SeparatorTemplate>
                    <hr />
                </SeparatorTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="odsjournal" runat="server" 
             onselecting="odsjournal_Selecting" SelectMethod="BLL__select_Journaltable" 
             TypeName="Mybloge.BLL.BLL_Journal">
                <SelectParameters>
                    <asp:Parameter Name="jour" Type="String" />
                </SelectParameters>
           </asp:ObjectDataSource>






            <div id="j1" >
        <asp:LinkButton ID="lbfirstPage" runat="server" onclick="lbfirstPage_Click" 
                    ForeColor="White">首页  </asp:LinkButton>
        <asp:LinkButton ID="lbbeforePage" runat="server" onclick="lbbeforePage_Click" 
                    ForeColor="White" >上一页  </asp:LinkButton>
        <asp:LinkButton ID="lbafterPage" runat="server" onclick="lbafterPage_Click"  ForeColor="White">下一页  </asp:LinkButton>
        <asp:LinkButton ID="lblastPage" runat="server" onclick="lblastPage_Click" ForeColor="White">  尾页 </asp:LinkButton>
        <asp:TextBox ID="txtPage" runat="server" Width="54px" Height="30px"></asp:TextBox>
        <asp:LinkButton ID="lbgo" runat="server" onclick="lbgo_Click"  ForeColor="White">          跳转</asp:LinkButton>
        <asp:Label ID="lblcount" runat="server" ForeColor="#ffffff"></asp:Label>
        <asp:Label ID="lblNow" runat="server" ForeColor="#ffffff"></asp:Label>
    </div>
       </div>
</asp:Content>

