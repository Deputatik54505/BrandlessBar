namespace brandlessBar.Utils
{
	public static class ImageUtils
	{

		public static byte[] ImageToByteArray(Image imageIn)
		{
			using (var ms = new MemoryStream())
			{
				imageIn.SaveAsGif(ms);

				return ms.ToArray();
			}
		}

		public static Image ByteArrayToImage(byte[] byteArrayIn)
		{
			using (var ms = new MemoryStream(byteArrayIn))
			{
				var returnImage = Image.Load(ms);

				return returnImage;
			}
		}


	}
}
