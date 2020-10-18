using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ChessLib.Pieces;

namespace ChessLib.State
{
    public class PiecesState : IEnumerable<Piece>
    {
        private Dictionary<(int x, int y), Piece> Pieces = new Dictionary<(int x, int y), Piece>();

        public Piece this[(int x, int y) position]
        {
            get => Pieces[position];
        }

        public PiecesState() { }

        public PiecesState(IEnumerable<Piece> pieces)
        {
            foreach (var piece in pieces)
                Pieces.Add(piece.Position, piece);
        }

        public void Place(Piece piece)
        {
            Pieces[piece.Position] = piece;
        }

        public bool IsOccupied((int x, int y) position) =>
            Pieces.ContainsKey(position);

        public bool IsOccupiedBy((int x, int y) position, string color) =>
            Pieces.TryGetValue(position, out Piece piece) && piece.Color == color;

        public bool IsOccupiedByOtherColor((int x, int y) position, string selfColor) =>
            Pieces.TryGetValue(position, out Piece piece) && piece.Color != selfColor;

        public IEnumerator<Piece> GetEnumerator() =>
            Pieces.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}