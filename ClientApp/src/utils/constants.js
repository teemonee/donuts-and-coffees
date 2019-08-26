const constants = { 
    GAME_FETCH_ERROR: "Error fetching new game!",
    BOARD_MARK_REQUEST_ERROR:"Error posting to server!",
    NEW_GAME_URL:"/api/Game/GetNewGameSession",
    CREATE_MOVE_URL:"/api/Game/CreateMove",
    AXIOS_JSON_HEADERS: { 
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
        }
    }
};

export default constants;