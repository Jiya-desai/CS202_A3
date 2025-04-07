import os
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns

# Paths
base_dir = r"C:\Users\jiyad\OneDrive\Desktop\IITGN\Software Tools and Techniques\CS202_Lab9\pydantic"
fan_data_csv = os.path.join(base_dir, "fan_data.csv")
vis_dir = os.path.join(base_dir, "visualizations")

# Ensure visualizations directory exists
os.makedirs(vis_dir, exist_ok=True)

# Load the fan-in/fan-out data
print("Loading fan data from CSV...")
df = pd.read_csv(fan_data_csv)

# Calculate combined metric (fan-in + fan-out)
df['Combined'] = df['Fan-In'] + df['Fan-Out']

# Basic stats
print("\nBasic Statistics:")
print(f"Total modules: {len(df)}")
print(f"Average Fan-In: {df['Fan-In'].mean():.2f}")
print(f"Average Fan-Out: {df['Fan-Out'].mean():.2f}")
print(f"Max Fan-In: {df['Fan-In'].max()} (Module: {df.loc[df['Fan-In'].idxmax()]['Module']})")
print(f"Max Fan-Out: {df['Fan-Out'].max()} (Module: {df.loc[df['Fan-Out'].idxmax()]['Module']})")

# Set plot style
sns.set(style="whitegrid")
plt.rcParams.update({'font.size': 12})

# 1. Top modules by Fan-In
print("\nCreating visualizations...")
top_n = 15  # Number of top modules to show
top_fan_in = df.sort_values('Fan-In', ascending=False).head(top_n)
plt.figure(figsize=(12, 8))
sns.barplot(x='Fan-In', y='Module', data=top_fan_in, palette='Blues_d')
plt.title(f'Top {top_n} Modules by Fan-In (Dependency Consumers)')
plt.tight_layout()
plt.savefig(os.path.join(vis_dir, 'top_fan_in.png'), dpi=300)

# 2. Top modules by Fan-Out
top_fan_out = df.sort_values('Fan-Out', ascending=False).head(top_n)
plt.figure(figsize=(12, 8))
sns.barplot(x='Fan-Out', y='Module', data=top_fan_out, palette='Oranges_d')
plt.title(f'Top {top_n} Modules by Fan-Out (Dependency Providers)')
plt.tight_layout()
plt.savefig(os.path.join(vis_dir, 'top_fan_out.png'), dpi=300)

# 3. Top modules by combined Fan-In + Fan-Out
top_combined = df.sort_values('Combined', ascending=False).head(top_n)
plt.figure(figsize=(12, 8))
sns.barplot(x='Combined', y='Module', data=top_combined, palette='Greens_d')
plt.title(f'Top {top_n} Modules by Combined Dependencies')
plt.tight_layout()
plt.savefig(os.path.join(vis_dir, 'top_combined.png'), dpi=300)

# 4. Scatter plot showing Fan-In vs Fan-Out
plt.figure(figsize=(12, 10))
scatter = plt.scatter(
    df['Fan-Out'], 
    df['Fan-In'],
    c=df['Combined'],
    cmap='viridis',
    alpha=0.7,
    s=100
)

# Add labels for top modules
top_modules = df.sort_values('Combined', ascending=False).head(10)
for _, row in top_modules.iterrows():
    plt.annotate(
        row['Module'].split('.')[-1],  # Use just the last part of the module name
        xy=(row['Fan-Out'], row['Fan-In']),
        xytext=(5, 5),
        textcoords='offset points',
        fontsize=9,
        bbox=dict(boxstyle="round,pad=0.3", fc="white", alpha=0.7)
    )

plt.colorbar(scatter, label='Combined Dependencies')
plt.title('Fan-In vs Fan-Out Analysis')
plt.xlabel('Fan-Out (Number of Dependencies)')
plt.ylabel('Fan-In (Number of Dependent Modules)')
plt.grid(True, linestyle='--', alpha=0.7)
plt.axhline(y=df['Fan-In'].mean(), color='r', linestyle='--', alpha=0.5)
plt.axvline(x=df['Fan-Out'].mean(), color='r', linestyle='--', alpha=0.5)
plt.tight_layout()
plt.savefig(os.path.join(vis_dir, 'fan_in_vs_fan_out.png'), dpi=300)

# 5. Distribution of Fan-In and Fan-Out
plt.figure(figsize=(16, 6))

plt.subplot(1, 2, 1)
sns.histplot(df['Fan-In'], kde=True, color='skyblue')
plt.title('Distribution of Fan-In')
plt.xlabel('Fan-In Count')
plt.ylabel('Number of Modules')

plt.subplot(1, 2, 2)
sns.histplot(df['Fan-Out'], kde=True, color='salmon')
plt.title('Distribution of Fan-Out')
plt.xlabel('Fan-Out Count')
plt.ylabel('Number of Modules')

plt.tight_layout()
plt.savefig(os.path.join(vis_dir, 'distribution.png'), dpi=300)

# 6. Generate a heatmap for the most interconnected modules
top_modules_count = 20
top_modules = df.nlargest(top_modules_count, 'Combined')['Module'].tolist()

print(f"\nVisualizations saved to: {vis_dir}")
print("✅ Visualization completed successfully.")