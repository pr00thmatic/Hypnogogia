using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Conversations {
[CreateAssetMenu(fileName = "conversation",
menuName = "pr00/Conversation")]
public class ConversationData : ScriptableObject {
  public LocalizedConversation[] convo;
  public PieceOfChat[] chat {
    get {
      foreach (LocalizedConversation c in convo) {
        if (c.location == Localization.selected) return c.chat;
      }
      return convo[0].chat;
    }
  }
}
}
