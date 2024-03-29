using Chatter.Application.Dtos.Rooms;
using Chatter.Application.Services.Chats;
using Chatter.Application.Services.Rooms;
using Chatter.Domain.Entities.EFCore.Identity;
using Chatter.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chatter.WebApp.Controllers;

[Authorize]
public class RoomController : Controller
{
    private readonly IRoomService _roomService;
    private readonly UserManager<ChatterUser> _userManager;

    private readonly IChatService _chatService;

    // GET
    public RoomController(IRoomService roomService, UserManager<ChatterUser> userManager, IChatService chatService)
    {
        _roomService = roomService;
        _userManager = userManager;
        _chatService = chatService;
    }

    public async Task<IActionResult> Index()
    {
        List<RoomDto> rooms;
        if (User.IsInRole("Admin"))
            rooms = await _roomService.GetRoomsAsync();
        else
            rooms = await _roomService.GetPublicRooms();
        return View(rooms);
    }

    [HttpGet]
    public async Task<IActionResult> MyRooms()
    {
        var user = await _userManager.GetUserAsync(User);
        var rooms = await _roomService.GetRoomsByUserIdAsync(user.Id);
        return View("Index", rooms);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomInput createRoomInput)
    {
        var user = await _userManager.GetUserAsync(User);
        createRoomInput.Users.Add(user);

        await _roomService.CreateRoomAsync(createRoomInput);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Detail(int id)
    {
        var room = await _roomService.GetRoomDetailAsync(id);
        var chatMessages = await _chatService.GetChatMessagesAsync(id);

        ViewBag.ChatMessages = chatMessages;
        ViewBag.CurrentUserId = _userManager.GetUserId(User);

        return View(room);
    }
    
    [HttpGet]
    public async Task<IActionResult> Chat(int id)
    {
        var room = await _roomService.GetRoomDetailAsync(id);
        var chatMessages = await _chatService.GetChatMessagesAsync(id);

        ViewBag.ChatMessages = chatMessages;
        ViewBag.CurrentUserId = _userManager.GetUserId(User);

        return View(room);
    }

    [HttpPost]
    public async Task<IActionResult> JoinRoom(int roomId)
    {
        var user = await _userManager.GetUserAsync(User);
        var joinRoomInput = new JoinRoomInput
        {
            RoomId = roomId,
            UserId = user.Id
        };
        await _roomService.JoinRoomAsync(joinRoomInput);
        return RedirectToAction("Chat", new {id = roomId});
    }

    [HttpPost]
    public async Task<IActionResult> LeaveRoom(int roomId)
    {
        var user = await _userManager.GetUserAsync(User);
        var leaveRoomInput = new LeaveRoomInput()
        {
            RoomId = roomId,
            UserId = user.Id
        };
        await _roomService.LeaveRoomAsync(leaveRoomInput);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteRoom(int roomId)
    {
        var user = await _userManager.GetUserAsync(User);
        var deleteRoomInput = new DeleteRoomInput()
        {
            RoomId = roomId,
            UserId = user.Id
        };
        await _roomService.DeleteRoomAsync(deleteRoomInput);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> EditRoom(EditRoomInput editRoomInput)
    {
        var user = await _userManager.GetUserAsync(User);
        editRoomInput.UserId = user.Id;
        await _roomService.EditRoomAsync(editRoomInput);
        return RedirectToAction("Chat", new {id = editRoomInput.Id});
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAdminToRoom(AddPermissionToRoomInput addPermissionToRoomInput)
    {
        var user = await _userManager.GetUserAsync(User);
        addPermissionToRoomInput.RequestedUserId = user.Id;
        addPermissionToRoomInput.PermissionType = ChatPermissionType.Admin;
        await _roomService.AddPermissionToRoomAsync(addPermissionToRoomInput);
        
        return RedirectToAction("Chat", new {id = addPermissionToRoomInput.RoomId});
    }
    
    [HttpPost]
    public async Task<IActionResult> RemoveUserInRoom(RemoveUserInRoomInput removeUserInRoomInput)
    {
        var user = await _userManager.GetUserAsync(User);
        removeUserInRoomInput.RequestedUserId = user.Id;
        await _roomService.RemoveUserInRoomAsync(removeUserInRoomInput);
        
        return RedirectToAction("Chat", new {id = removeUserInRoomInput.RoomId});
    }
  
}