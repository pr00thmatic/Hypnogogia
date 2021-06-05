using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Conversations {
[CreateAssetMenu(fileName = "conversation",
menuName = "pr00/Conversation")]
public class ConversationData : ScriptableObject {
  public PieceOfChat[] chat;
}
}
