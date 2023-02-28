# Talk to AI

## 建立 Slack App (bot)

1、請至 [https://api.slack.com/apps](https://api.slack.com/apps) 登入並點擊 Create New App 按鈕

![image](https://i.imgur.com/kqP2Nml.png)

2、請輸入 `App Name` 和 `Your Workspace` 並點擊 Create App 按鈕

![image](https://i.imgur.com/emgo5mu.png)

3、請點選左側選單 `OAuth & Permissions` 且滾動捲軸至 `Scope`，選擇三項必要的 Bot Token Scope

https://user-images.githubusercontent.com/12579766/221924819-b1675d0e-0a32-4ce4-86d7-5cce0f14ee11.mp4

| OAuth Scope            | Description                                                        |
| ---------------------- | ------------------------------------------------------------------ |
| `chat:write`           | Send messages as @Talk to AI                                       |
| `chat:write.customize` | Send messages as @Talk to AI with a customized username and avatar |
| `files:write`          | Upload, edit, and delete files as Talk to AI                       |

4、請點選左側選單 `Event Subscription`，並啟用 `Enable Events`，請輸入 `Request URL` (callback url) 進行驗證，再請到下方的 `Subscribe to bot events` 選擇一項必要的 `Bot User Event`。

![image](https://i.imgur.com/ADHXyfc.png)

| Event Name    | Description                                                         | Required Scope   |
| ------------- | ------------------------------------------------------------------- | ---------------- |
| `app_mention` | Subscribe to only the message events that mentation your app or bot | app_mentions:red |

## 安裝 Slack APP (bot)

1、請點選左側選單 `Install App`，並點擊 `Install Workspace` 按鈕
![image](https://i.imgur.com/0zsMNYf.png)

2、請到 Slack 中的任一個頻道，加入你新增的 App 進來頻道
![image](https://i.imgur.com/KIGWtIT.png)
![image](https://i.imgur.com/ZeWhJMs.png)

## 使用 Slack APP (bot)

1、呼叫機器人回答問題
![image](https://i.imgur.com/kFYyjyf.png)
