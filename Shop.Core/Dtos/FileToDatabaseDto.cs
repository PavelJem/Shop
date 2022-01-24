using System;

namespace Shop.Core.Dtos
{
    public class FileToDatabaseDto
    {
        //FileToDatabaseDto
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? SpaceshipId { get; set; }

    }
}
